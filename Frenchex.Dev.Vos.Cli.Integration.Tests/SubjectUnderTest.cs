using System.CommandLine;

namespace Frenchex.Dev.Vos.Cli.Integration.Tests;

public class SubjectUnderTest
{
    public SubjectUnderTest()
    {
        RootCommand = new RootCommand();
    }

    public RootCommand RootCommand { get; }
}