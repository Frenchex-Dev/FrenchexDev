#region Licensing

// Copyright Stéphane Erard 2023
// All rights reserved.
// 
// Licencing : stephane.erard@gmail.com
// 
// 

#endregion

namespace Frenchex.Dev.Vos.Lib.Abstractions.Domain.Actions.Configuration.Save;

public interface IConfigurationSaveAction
{
    Task Save(Domain.Configuration.Configuration configuration, string path);
}