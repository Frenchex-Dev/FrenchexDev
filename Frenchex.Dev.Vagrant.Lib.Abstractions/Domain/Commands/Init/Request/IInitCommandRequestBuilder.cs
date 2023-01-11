#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Request;

public interface IInitCommandRequestBuilder : IRootCommandRequestBuilder
{
    IInitCommandRequest Build();
    IInitCommandRequestBuilder UsingBoxName(string with);
    IInitCommandRequestBuilder UsingBoxUrl(string with);
    IInitCommandRequestBuilder UsingBoxVersion(string with);
    IInitCommandRequestBuilder WithForce(bool with);
    IInitCommandRequestBuilder WithMinimal(bool with);
    IInitCommandRequestBuilder UsingOutputToFile(string with);
    IInitCommandRequestBuilder UsingTemplateFile(string with);
}