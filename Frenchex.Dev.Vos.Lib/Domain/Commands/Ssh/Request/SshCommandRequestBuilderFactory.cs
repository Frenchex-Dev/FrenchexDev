﻿#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vos.Lib.Abstractions.Domain.Commands.Ssh.Request;
using Frenchex.Dev.Vos.Lib.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vos.Lib.Domain.Commands.Ssh.Request;

public class SshCommandRequestBuilderFactory : RootCommandRequestBuilderFactory, ISshCommandRequestBuilderFactory
{
    public SshCommandRequestBuilderFactory(IBaseRequestBuilderFactory baseRequestBuilderFactory) : base(
        baseRequestBuilderFactory)
    {
    }

    public ISshCommandRequestBuilder Factory()
    {
        return new SshCommandRequestBuilder(BaseRequestBuilderFactory);
    }
}