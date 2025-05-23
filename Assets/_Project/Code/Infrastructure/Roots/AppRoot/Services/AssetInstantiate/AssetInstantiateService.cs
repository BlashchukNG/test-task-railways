using Infrastructure.DI;
using Infrastructure.Roots.AppRoot.Services.Updater;
using UnityEngine;
using Utils.Coroutiner;

namespace Infrastructure.Roots.AppRoot.Services.AssetInstantiate
{
	public sealed class AssetInstantiateService : IAssetInstantiateService
	{
		private readonly DIContainer _diContainer;

		public AssetInstantiateService(DIContainer diContainer)
		{
			_diContainer = diContainer;
		}

		public CoroutineRunner GetCoroutineRunner()
		{
			var coroutineRunner = new GameObject("[COROUTINE RUNNER]")
				.AddComponent<CoroutineRunner>();
			Object.DontDestroyOnLoad(coroutineRunner.gameObject);

			return coroutineRunner;
		}

		public IUpdateService GetUpdater()
		{
			var updater = new GameObject("[UPDATE SERVICE]")
				.AddComponent<UpdateService>();

			return updater;
		}

		public T GetInstance<T>(T prefab, Transform root = null, Vector3 position = default, Quaternion rotation = default, bool isDontDestroyOnLoad = false)
			where T : MonoBehaviour
		{
			var instance = Object.Instantiate(prefab, position, Quaternion.identity, root);
			if (isDontDestroyOnLoad) Object.DontDestroyOnLoad(instance.gameObject);
			return instance;
		}
	}
}