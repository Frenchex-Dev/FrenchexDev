using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Request;

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Request;

public interface INameCommandRequestBuilder : IRootCommandRequestBuilder
{
    INameCommandRequest Build();
    INameCommandRequestBuilder WithNames(string[] names);
}