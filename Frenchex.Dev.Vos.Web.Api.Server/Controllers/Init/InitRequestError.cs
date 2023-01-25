using Frenchex.Dev.Vos.Web.Api.Server.Bases;

namespace Frenchex.Dev.Vos.Web.Api.Server.Controllers.Init;

public class InitRequestError : IError
{
    public string Error { get; set; }
}