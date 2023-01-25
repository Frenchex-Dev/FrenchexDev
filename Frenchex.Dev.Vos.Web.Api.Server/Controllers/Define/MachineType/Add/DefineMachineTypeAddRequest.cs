using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;
using Frenchex.Dev.Vos.Web.Api.Server.Bases;

namespace Frenchex.Dev.Vos.Web.Api.Server.Controllers.Define.MachineType.Add;

public class DefineMachineTypeAddRequest : IRequest
{
    public Guid RepositoryId { get; set; }
    public MachineTypeDefinitionDeclaration MachineTypeDefinitionDeclaration { get; set; }
}