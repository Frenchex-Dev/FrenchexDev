using Frenchex.Dev.Vos.Web.Api.Server.Bases;

namespace Frenchex.Dev.Vos.Web.Api.Server.Controllers.Define.MachineType.Add;

public class DefineMachineTypeAddResponse : IResponse<DefineMachineTypeAddError>
{
    public bool IsSuccess { get; set; }
    public List<DefineMachineTypeAddError> Errors { get; set; }
}