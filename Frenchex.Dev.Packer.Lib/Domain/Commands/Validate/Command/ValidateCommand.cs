#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

#region

using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Validate.Command;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Validate.Request;
using Frenchex.Dev.Packer.Lib.Abstractions.Domain.Commands.Validate.Response;

#endregion

namespace Frenchex.Dev.Packer.Lib.Domain.Commands.Validate.Command;

public class ValidateCommand : IValidateCommand
{
    public string GetCliCommandName()
    {
        return "validate";
    }


    public IValidateCommandResponse StartProcess(IValidateCommandRequest request)
    {
        throw new NotImplementedException();
    }
}