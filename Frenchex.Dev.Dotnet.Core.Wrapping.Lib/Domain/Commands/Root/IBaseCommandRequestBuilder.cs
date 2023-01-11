#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

namespace Frenchex.Dev.Dotnet.Wrapping.Lib.Domain.Commands.Root;

public interface IBaseCommandRequestBuilder
{
    IBaseCommandRequest Build();
    T Parent<T>() where T : IRootCommandRequestBuilder;
    IBaseCommandRequestBuilder UsingWorkingDirectory(string? workingDirectory);
    IBaseCommandRequestBuilder UsingTimeout(string timeout);
    IBaseCommandRequestBuilder UsingBinPath(string binPath);
}