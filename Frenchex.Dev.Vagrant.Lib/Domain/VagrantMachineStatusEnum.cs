namespace Frenchex.Dev.Vagrant.Lib.Domain;

public enum VagrantMachineStatusEnum
{
    NotCreated,
    Aborted,
    Running,
    Stopped,
    Suspended
}

public class Statuses
{
    public readonly static string NotCreated = "not created";
    public readonly static string Running = "running";
    public readonly static string Aborted = "aborted";
    public readonly static string Suspended = "suspended";
    public readonly static string Stopped = "stopped";

    public string ToString(VagrantMachineStatusEnum status)
    {
        if (status == VagrantMachineStatusEnum.NotCreated)
            return NotCreated;

        if (status == VagrantMachineStatusEnum.Running)
            return Running;

        if (status == VagrantMachineStatusEnum.Aborted)
            return Aborted;

        if (status == VagrantMachineStatusEnum.Stopped)
            return Stopped;

        if (status == VagrantMachineStatusEnum.Suspended)
            return Suspended;

        throw new InvalidOperationException("unknown enum status value");
    }

    public VagrantMachineStatusEnum ToEnum(string status)
    {
        if (status == NotCreated)
            return VagrantMachineStatusEnum.NotCreated;

        if (status == Running)
            return VagrantMachineStatusEnum.Running;

        if (status == Aborted)
            return VagrantMachineStatusEnum.Aborted;

        if (status == Stopped)
            return VagrantMachineStatusEnum.Stopped;

        if (status == Suspended)
            return VagrantMachineStatusEnum.Suspended;

        throw new InvalidOperationException("unknown string status value");
    }
}