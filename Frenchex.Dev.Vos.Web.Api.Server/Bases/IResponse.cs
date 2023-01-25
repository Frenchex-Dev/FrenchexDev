namespace Frenchex.Dev.Vos.Web.Api.Server.Bases;

public interface IResponse<T>
    where T : IError
{
    public bool IsSuccess { get; set; }
    public List<T> Errors { get; set; }
}