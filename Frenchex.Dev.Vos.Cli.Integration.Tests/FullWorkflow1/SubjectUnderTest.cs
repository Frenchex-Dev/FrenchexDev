#region Licensing

// Copyright St�phane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using System.CommandLine;

#endregion

namespace Frenchex.Dev.Vos.Cli.Integration.Tests.FullWorkflow1;

public class SubjectUnderTest
{
    public SubjectUnderTest()
    {
        RootCommand = new RootCommand();
    }

    public RootCommand RootCommand { get; }
}