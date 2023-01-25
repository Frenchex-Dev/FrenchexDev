using Frenchex.Dev.Vos.Web.Api.Server.Bases;

namespace Frenchex.Dev.Vos.Web.Api.Server.Controllers.Init;

public class InitResponse : IResponse<InitRequestError>
{
    public bool IsSuccess { get; set; }
    public List<InitRequestError> Errors { get; set; }
}