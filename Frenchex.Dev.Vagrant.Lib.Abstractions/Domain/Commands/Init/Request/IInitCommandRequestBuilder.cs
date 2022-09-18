using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Request;

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