using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Status.Request;

public interface IStatusCommandRequestBuilder : IRootCommandRequestBuilder
{
    IStatusCommandRequest Build();
    IStatusCommandRequestBuilder WithNames(string[] name);
}