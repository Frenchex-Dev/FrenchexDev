using Frenchex.Dev.Vos.Web.Api.Server.Bases;

namespace Frenchex.Dev.Vos.Web.Api.Server.Controllers.Init;

public class InitRequest : IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}