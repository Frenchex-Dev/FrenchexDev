#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Naming;

public interface IVexNameToVagrantNameConverter
{
    string[] ConvertAll(string[] names, string? workingDirectory, Domain.Configuration.Configuration configuration);
}