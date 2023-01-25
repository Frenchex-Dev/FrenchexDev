using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Definitions;
using Frenchex.Dev.Vos.Web.Api.Server.Bases;

namespace Frenchex.Dev.Vos.Web.Api.Server.Controllers.Define.Machine.Add;

public class DefineMachineAddRequest : IRequest
{
    public Guid RepositoryId { get; set; }
    public MachineDefinitionDeclaration MachineDefinition { get; set; }
}