#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Root.Base.Request;

public interface IBaseCommandRequestBuilder
{
    IBaseCommandRequest Build();
    T Parent<T>() where T : IRootCommandRequestBuilder;
    IBaseCommandRequestBuilder WithColor(bool with);
    IBaseCommandRequestBuilder WithMachineReadable(bool with);
    IBaseCommandRequestBuilder WithVersion(bool with);
    IBaseCommandRequestBuilder WithDebug(bool with);
    IBaseCommandRequestBuilder WithTimestamp(bool with);
    IBaseCommandRequestBuilder WithDebugTimestamp(bool with);
    IBaseCommandRequestBuilder WithTty(bool with);
    IBaseCommandRequestBuilder WithHelp(bool with);
    IBaseCommandRequestBuilder UsingWorkingDirectory(string? workingDirectory);
    IBaseCommandRequestBuilder UsingTimeout(string timeout);
}