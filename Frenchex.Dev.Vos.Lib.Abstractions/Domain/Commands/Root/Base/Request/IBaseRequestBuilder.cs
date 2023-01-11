#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;

public interface IBaseRequestBuilder
{
    IBaseCommandRequest Build();
    T Parent<T>();
    IBaseRequestBuilder SetParent(object parent);
    IBaseRequestBuilder WithColor(bool with);
    IBaseRequestBuilder WithMachineReadable(bool with);
    IBaseRequestBuilder WithVersion(bool with);
    IBaseRequestBuilder WithDebug(bool with);
    IBaseRequestBuilder WithTimestamp(bool with);
    IBaseRequestBuilder WithTty(bool with);
    IBaseRequestBuilder WithHelp(bool with);
    IBaseRequestBuilder UsingWorkingDirectory(string? workingDirectory);
    IBaseRequestBuilder UsingTimeout(string? timeoutString);
    IBaseRequestBuilder UsingVagrantBinPath(string? vagrantBinPath);
}