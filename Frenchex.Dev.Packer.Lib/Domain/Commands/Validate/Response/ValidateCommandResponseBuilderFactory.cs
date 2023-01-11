#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Validate.Response;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Validate.Response;

public class ValidateCommandResponseBuilderFactory : IValidateCommandResponseBuilderFactory
{
    private readonly IServiceProvider _serviceProvider;

    public ValidateCommandResponseBuilderFactory(
        IServiceProvider serviceProvider
    )
    {
        _serviceProvider = serviceProvider;
    }

    public IValidateCommandResponseBuilder Factory()
    {
        return _serviceProvider.GetRequiredService<IValidateCommandResponseBuilder>();
    }
}