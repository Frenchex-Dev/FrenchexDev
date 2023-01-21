﻿#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

#region

using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Init.Request;
using Frenchex.Dev.Vagrant.Lib.Abstractions.Domain.Commands.Root.Base.Request;
using Frenchex.Dev.Vagrant.Lib.Domain.Commands.Root.Request;

#endregion

namespace Frenchex.Dev.Vagrant.Lib.Domain.Commands.Init.Request;

public class InitCommandRequestBuilder : RootCommandRequestBuilder, IInitCommandRequestBuilder
{
    private string? _boxName;
    private string? _boxUrl;
    private string? _boxVersion;
    private bool? _force;
    private bool? _minimal;
    private string? _outputToFile;
    private string? _templateFile;

    public InitCommandRequestBuilder(
        IBaseCommandRequestBuilderFactory baseRequestBuilderFactory
    ) : base(baseRequestBuilderFactory)
    {
    }

    public IInitCommandRequest Build()
    {
        return new InitCommandRequest(
            _boxVersion,
            _force,
            _minimal,
            _outputToFile,
            _templateFile,
            _boxName,
            _boxUrl,
            BaseBuilder.Build()
        );
    }

    public IInitCommandRequestBuilder UsingBoxVersion(string boxVersion)
    {
        _boxVersion = boxVersion;
        return this;
    }

    public IInitCommandRequestBuilder WithForce(bool with)
    {
        _force = with;
        return this;
    }

    public IInitCommandRequestBuilder WithMinimal(bool with)
    {
        _minimal = with;
        return this;
    }

    public IInitCommandRequestBuilder UsingOutputToFile(string file)
    {
        _outputToFile = file;
        return this;
    }

    public IInitCommandRequestBuilder UsingTemplateFile(string templateFile)
    {
        _templateFile = templateFile;
        return this;
    }

    public IInitCommandRequestBuilder UsingBoxName(string boxName)
    {
        _boxName = boxName;
        return this;
    }

    public IInitCommandRequestBuilder UsingBoxUrl(string boxUrl)
    {
        _boxUrl = boxUrl;
        return this;
    }
}