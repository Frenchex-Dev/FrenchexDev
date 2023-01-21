#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Name.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Tests.Domain.UseCases.FullWorkflow2;

public class NameCommandRequestPayload
{
    public NameCommandRequestPayload(INameCommandRequest request)
    {
        Request = request;
    }

    public INameCommandRequest Request { get; init; }
    public List<string> ExpectedNames { get; set; } = new();
}