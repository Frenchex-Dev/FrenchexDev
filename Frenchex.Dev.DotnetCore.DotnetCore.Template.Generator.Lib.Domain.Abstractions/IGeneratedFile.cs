﻿namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

public interface IGeneratedFile
{
    string FileName  { get; }
    string Extension { get; }
    string Path      { get; }
    string Content   { get; }
}