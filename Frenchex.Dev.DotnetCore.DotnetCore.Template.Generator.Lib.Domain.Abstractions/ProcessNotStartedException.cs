﻿namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions;

public class ProcessNotStartedException(
    string message
) : Exception(message);
