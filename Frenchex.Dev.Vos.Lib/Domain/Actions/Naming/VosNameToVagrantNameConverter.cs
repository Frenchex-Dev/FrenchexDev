#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using System.Text.RegularExpressions;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Naming;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Actions.Naming;

public class VosNameToVagrantNameConverter : IVosNameToVagrantNameConverter
{
    private static readonly Regex PatternFromToWildcard =
        new("(?<machine>.*)\\-\\[(?<instance>.*)\\]", RegexOptions.Compiled);

    private static readonly Regex PatternFromTo = new("(?<machine>.*)\\-(?<instance>.*)", RegexOptions.Compiled);


    public string[] ConvertAll(
        string[] inputNamedPatterns,
        string? workingDirectory,
        Abstractions.Domain.Configuration.Configuration configuration
    )
    {
        return ConvertAllInternal(
            inputNamedPatterns,
            workingDirectory,
            configuration,
            false
        );
    }

    public string[] GetMachineNames(
        string[] inputNamedPatterns,
        string? workingDirectory,
        Abstractions.Domain.Configuration.Configuration configuration
    )
    {
        return ConvertAllInternal(
            inputNamedPatterns,
            workingDirectory,
            configuration,
            true
        );
    }

    public string[] ConvertAllInternal(
        string[] inputNamedPatterns,
        string? workingDirectory,
        Abstractions.Domain.Configuration.Configuration configuration,
        bool machineNames
    )
    {
        if (null == configuration) throw new ArgumentNullException(nameof(configuration));

        var list = new List<string>();
        string? dirBase = Path.GetFileName(workingDirectory);

        if (null == dirBase)
            throw new ArgumentNullException(nameof(dirBase));

        bool prefixWithDirBase = configuration.Vagrant.PrefixWithDirBase;
        string? namingPattern = configuration.Vagrant.NamingPattern;

        foreach (string? inputNamedPattern in inputNamedPatterns)
        {
            string? cleanInputNamePattern = inputNamedPattern.Trim().Trim('"', '\'').ToLowerInvariant();
            MatchCollection? matchesPatternFromToWildcard = PatternFromToWildcard.Matches(cleanInputNamePattern);
            var from = 0;
            var to = 0;
            var machineName = "";
            var instances = "";

            switch (matchesPatternFromToWildcard.Count)
            {
                case 0:
                {
                    MatchCollection? matchesPatternFromTo = PatternFromTo.Matches(cleanInputNamePattern);

                    Match? firstMatches = matchesPatternFromTo.FirstOrDefault();

                    if (firstMatches == null && machineNames)
                    {
                        list.Add(cleanInputNamePattern);
                        continue;
                    }

                    if (firstMatches.Groups.ContainsKey("machine"))
                        machineName = firstMatches.Groups["machine"].Value.Trim().ToLowerInvariant();

                    if (machineNames)
                    {
                        list.Add(machineName);
                        continue;
                    }

                    if (firstMatches.Groups.ContainsKey("instance"))
                        instances = firstMatches.Groups["instance"].Value.Trim().ToLowerInvariant();

                    if (instances == "*")
                        to = (configuration?.Machines[machineName].Instances ?? 0) - 1;
                    else
                        from = to = int.Parse(instances);

                    break;
                }
                case > 0:
                {
                    Match? firstMatches = matchesPatternFromToWildcard.First();

                    if (firstMatches.Groups.ContainsKey("machine"))
                        machineName = firstMatches.Groups["machine"].Value.Trim().ToLowerInvariant();

                    if (firstMatches.Groups.ContainsKey("instance"))
                        instances = firstMatches.Groups["instance"].Value.Trim().ToLowerInvariant();


                    if (instances.Contains('-')) // [2-*], [2-3-4], 
                    {
                        string[]? instancesSplit = instances.Split('-');

                        from = int.Parse(instancesSplit[0]);

                        if (instancesSplit.Length == 2)
                        {
                            string? instanceSplitTo = instancesSplit[1];

                            if (instanceSplitTo == "*")
                            {
                                if (!configuration.Machines.ContainsKey(machineName))
                                    throw new Exception($"unknown machine  ${machineName}");
                                to = configuration?.Machines[machineName]?.Instances - 1 ?? 0;
                            }
                            else
                            {
                                to = int.Parse(instanceSplitTo);
                            }
                        }
                    }

                    break;
                }
            }

            if (from > to)
                throw new InvalidDataException("from is gt to");

            for (int i = from; i <= to; i++)
            {
                string? instanceAsStr = string.Format(
                    $"{{0,{configuration?.Vagrant?.Zeroes}:D{configuration?.Vagrant?.Zeroes}}}",
                    i);

                list.Add(
                    Prefix(
                        machineName,
                        instanceAsStr,
                        prefixWithDirBase,
                        dirBase,
                        namingPattern
                    )
                );
            }
        }

        return list.ToArray();
    }

    private static string Prefix(
        string s,
        string instance,
        bool prefixWithDirBase,
        string dirBase,
        string namingPattern
    )
    {
        return (prefixWithDirBase ? dirBase + "-" : "")
               + namingPattern
                   .Replace("#MACHINE-NAME#", s)
                   .Replace("#MACHINE-INSTANCE#", instance)
            ;
    }
}