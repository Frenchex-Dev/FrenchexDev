using Frenchex.Dev.Vos.Web.Api.Server.Bases;

namespace Frenchex.Dev.Vos.Web.Api.Server.Controllers.Define.Machine.Add;

public class DefineMachineAddResponse : IResponse<DefineMachineAddError>
{
    public bool IsSuccess { get; set; }
    public List<DefineMachineAddError> Errors { get; set; }
}