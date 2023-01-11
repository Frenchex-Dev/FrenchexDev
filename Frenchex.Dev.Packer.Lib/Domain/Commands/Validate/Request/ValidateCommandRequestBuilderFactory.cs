#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Validate.Request;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Validate.Request;

public class ValidateCommandRequestBuilderFactory : IValidateCommandRequestBuilderFactory
{
    private readonly IServiceProvider _serviceProvider;

    public ValidateCommandRequestBuilderFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IValidateCommandRequestBuilder Factory()
    {
        return _serviceProvider.GetRequiredService<IValidateCommandRequestBuilder>();
    }
}