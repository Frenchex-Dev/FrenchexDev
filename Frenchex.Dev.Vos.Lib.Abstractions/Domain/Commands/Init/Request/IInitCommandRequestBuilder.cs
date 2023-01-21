﻿#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Init.Request;

public interface IInitCommandRequestBuilder : IRootCommandRequestBuilder
{
    IInitCommandRequest Build();
    IInitCommandRequestBuilder WithNamingPattern(string namingPattern);
    IInitCommandRequestBuilder WithGivenLeadingZeroes(int leadingZeroes);
}