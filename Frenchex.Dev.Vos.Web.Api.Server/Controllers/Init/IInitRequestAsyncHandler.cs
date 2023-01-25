using Frenchex.Dev.Vos.Web.Api.Server.Bases;

namespace Frenchex.Dev.Vos.Web.Api.Server.Controllers.Init;

public interface IInitRequestAsyncHandler : IAsyncHandler<InitRequest, InitResponse, InitRequestError>
{
}