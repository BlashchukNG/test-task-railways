using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Roots.AppRoot.Services.ResourceLoader
{
	public sealed class ResourceLoaderService : IResourceLoaderService
	{
		private readonly Dictionary<string, string> _resources = new();

		// public ResourceLoaderService()
		// {
		// 	var config = Resources.Load<GeneralResourcesConfig>(ResourcesConstants.CONFIG_GENERAL_RESOURCES);
		//
		// 	foreach (var resource in config.resources)
		// 	{
		// 		if (!_resources.TryAdd(resource.name, resource.path))
		// 			throw new Exception($"ResourceLoader: {resource.name} already exists");
		// 	}
		// }
		//
		// public UIRootView GetPrefabUIRootView() => Load<UIRootView>(ResourcesConstants.UI_ROOT_VIEW);
		// public CameraController GetPrefabCameraController() => Load<CameraController>(ResourcesConstants.CAMERA_CONTROLLER);
		// public SaveFileConfig GetBaseSaveFile() => Resources.Load<SaveFileConfig>(ResourcesConstants.CONFIG_BASE_SAVE_FILE);
		// public LocomotionSettings GetPlayerLocomotionSettings() => Resources.Load<LocomotionSettingsConfig>(_resources["config player locomotion settings"]).settings;
		//
		// public T GetPrefab<T>(string name)
		// 	where T : MonoBehaviour =>
		// 	Load<T>(name);

		private T Load<T>(string name)
			where T : MonoBehaviour =>
			Resources.Load<T>(_resources[name]);
	}
}