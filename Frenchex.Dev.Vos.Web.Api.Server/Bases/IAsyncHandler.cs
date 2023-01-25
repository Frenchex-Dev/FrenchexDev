using Frenchex.Dev.Vos.Web.Api.Server.Exceptions;

namespace Frenchex.Dev.Vos.Web.Api.Server.Bases;

public interface IAsyncHandler<in T, TR, E>
    where TR : IResponse<E>
    where T : IRequest
    where E : IError
{
    Task<TR> HandleAsync(T request, CancellationToken cancellationToken = default);
}

public abstract class AbstractAsyncHandler
{
    protected string GetRepositoryPathOrThrowRepositoryNotFound(Guid repositoryId, IConfiguration configuration)
    {
        var rootPath = GetVosRootPathFromConfiguration(configuration);

        if (rootPath == null)
        {
            throw new ArgumentNullException(nameof(rootPath));
        }

        string repositoryPath = Path.Join(rootPath, repositoryId.ToString());

        if (!Directory.Exists(repositoryPath))
        {
            throw new RepositoryNotFound();
        }

        return repositoryPath;
    }

    protected string? GetVosRootPathFromConfiguration(IConfiguration configuration)
    {
        return configuration.GetSection("VagrantOnSteroid").GetValue<string>("RootPath");
    }
}