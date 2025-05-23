using Infrastructure.Roots.AppRoot.Services.Updater;
using UnityEngine;
using Utils.Coroutiner;

namespace Infrastructure.Roots.AppRoot.Services.AssetInstantiate
{
	public interface IAssetInstantiateService
	{
		CoroutineRunner GetCoroutineRunner();
		IUpdateService GetUpdater();

		T GetInstance<T>(T prefab, Transform root = null, Vector3 position = default, Quaternion rotation = default, bool isDontDestroyOnLoad = false)
			where T : MonoBehaviour;
	}
}