
namespace Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands;

public interface IFacade<out TR1, out TR2, out TR3>
    where TR1 : class
    where TR2 : class
    where TR3 : class
{
    TR1 Command { get; }
    TR2 RequestBuilderFactory { get; }
    TR3 RequestBuilder { get; }
}