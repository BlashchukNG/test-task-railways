using System.Collections;
using Constants;
using Infrastructure.DI;
using Infrastructure.Roots.GameplayScene.EnterExitParams;
using Infrastructure.Roots.GameplayScene.EntryPoint;
using R3;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils.Coroutiner;

namespace Infrastructure.Roots.AppRoot.Services.SceneLoader
{
	public sealed class SceneLoaderService : ISceneLoaderService
	{
		private DIContainer _cashedSceneDIContainer;

		private readonly WaitForSeconds _delayBetweenScenes = new(InfrastructureConstants.DELAY_BETWEEN_SCENES);
		private readonly WaitForSeconds _delayBeforeLoadScene = new(InfrastructureConstants.SHOW_HIDE_LOADING_SCREEN_DURATION);

		private readonly DIContainer _diContainer;
		private readonly UIRootView _uiRootView;
		private readonly CoroutineRunner _coroutineRunner;

		public SceneLoaderService(DIContainer diContainer)
		{
			_diContainer = diContainer;
			_uiRootView = _diContainer.Resolve<UIRootView>();
			_coroutineRunner = _diContainer.Resolve<CoroutineRunner>();
		}

		#region Gameplay

		public void LoadGameplay(GameplayEnterParams enterParams = null) => _coroutineRunner.StartCoroutine(LoadGameplayRoutine(enterParams));

		private IEnumerator LoadGameplayRoutine(GameplayEnterParams enterParams)
		{
			_uiRootView.ShowLoadingScreen();
			_cashedSceneDIContainer?.Dispose();

			yield return _delayBeforeLoadScene;
			yield return LoadScene(Scenes.BOOT);
			yield return LoadScene(Scenes.GAMEPLAY);
			yield return _delayBetweenScenes;

			var diContainer = _cashedSceneDIContainer = new DIContainer(_diContainer);

			var sceneEntryPoint = Object.FindFirstObjectByType<GameplayEntryPoint>();
			sceneEntryPoint.Run(diContainer, enterParams)
			               .Subscribe(exitParams =>
			               {
				               Application.Quit();
			               });

			yield return _delayBeforeLoadScene;

			_uiRootView.HideLoadingScreen();
		}

		#endregion
		
		private IEnumerator LoadScene(string sceneName)
		{
			yield return SceneManager.LoadSceneAsync(sceneName);
		}
	}
}