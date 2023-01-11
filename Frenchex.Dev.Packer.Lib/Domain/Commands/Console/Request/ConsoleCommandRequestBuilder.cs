#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Console.Request;

#endregion

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Console.Request;

public class ConsoleCommandRequestBuilder : IConsoleCommandRequestBuilder
{
    public ConsoleCommandRequestBuilder(IBaseCommandRequestBuilderFactory baseBuilderFactory)
    {
        BaseBuilder = baseBuilderFactory.Factory(this);
    }

    public IBaseCommandRequestBuilder BaseBuilder { get; }

    public IConsoleCommandRequest Build()
    {
        throw new NotImplementedException();
    }
}