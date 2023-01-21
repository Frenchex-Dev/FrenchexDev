#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com

#endregion

[assembly: Parallelize(Workers = 4, Scope = ExecutionScope.MethodLevel)]