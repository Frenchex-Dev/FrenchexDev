namespace Frenchex.Dev.Vagrant.Lib.Domain.Abstractions.Commands.Init;

public interface IVagrantInitRequest
{
    string? Name       { get; set; }
    string? Url        { get; set; }
    string? BoxVersion { get; set; }
    bool    Force      { get; set; }
    bool    Minimal    { get; set; }
    string? Output     { get; set; }
    string? Template   { get; set; }
}
