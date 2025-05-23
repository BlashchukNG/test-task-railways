using Constants;
using Infrastructure.DI;
using Infrastructure.Roots.AppRoot;
using Infrastructure.Roots.AppRoot.Services.AssetInstantiate;
using Infrastructure.Roots.AppRoot.Services.ResourceLoader;
using Infrastructure.Roots.AppRoot.Services.SceneLoader;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils.Coroutiner;

namespace Infrastructure.Roots
{
	public sealed class AppEntryPoint
	{
		private static AppEntryPoint _instance;

		private readonly DIContainer _diContainer = new();

		private UIRootView _uiRootView;
		private CoroutineRunner _coroutineRunner;
		private IResourceLoaderService _resourceLoaderService;
		private IAssetInstantiateService _assetInstantiateService;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		public static void LoadApp()
		{
			//TODO: add global settings service
			Application.targetFrameRate = 60;
			Screen.sleepTimeout = SleepTimeout.NeverSleep;

			_instance = new AppEntryPoint();
			_instance.RunApp();
		}

		private AppEntryPoint()
		{
			InitServices();
		}

		private void RunApp()
		{
			var sceneLoader = _diContainer.Resolve<ISceneLoaderService>();
		#if UNITY_EDITOR
			var sceneName = SceneManager.GetActiveScene().name;

			switch (sceneName)
			{
				case Scenes.GAMEPLAY:
					sceneLoader.LoadGameplay();
					break;
			}

			if (sceneName != Scenes.BOOT)
				return;
		#endif

			sceneLoader.LoadGameplay();
		}

		private void InitServices()
		{
			_assetInstantiateService = new AssetInstantiateService(_diContainer);
			_diContainer.RegisterInstance(_assetInstantiateService);

			_resourceLoaderService = new ResourceLoaderService();
			_diContainer.RegisterInstance(_resourceLoaderService);

			_coroutineRunner = _assetInstantiateService.GetCoroutineRunner();
			_diContainer.RegisterInstance(_coroutineRunner);

			_uiRootView = _assetInstantiateService.GetInstance(Resources.Load<UIRootView>("ui root view"), isDontDestroyOnLoad: true);
			_diContainer.RegisterInstance(_uiRootView);

			_diContainer.RegisterInstance<ISceneLoaderService>(new SceneLoaderService(_diContainer));
		}
	}
}