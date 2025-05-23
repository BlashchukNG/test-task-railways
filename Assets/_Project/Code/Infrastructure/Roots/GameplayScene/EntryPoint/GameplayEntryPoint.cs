using Infrastructure.DI;
using Infrastructure.Roots.AppRoot;
using Infrastructure.Roots.AppRoot.Services.AssetInstantiate;
using Infrastructure.Roots.GameplayScene.EnterExitParams;
using Infrastructure.Roots.GameplayScene.Registrations;
using Infrastructure.Roots.GameplayScene.View;
using R3;
using UnityEngine;

namespace Infrastructure.Roots.GameplayScene.EntryPoint
{
	public sealed class GameplayEntryPoint : MonoBehaviour
	{
		[SerializeField] private UIGameplayRootBinder _uiRootBinderPrefab;

		private DIContainer _diContainer;
		private DIContainer _viewModelDIContainer;

		public Observable<GameplayExitParams> Run(DIContainer diContainer, GameplayEnterParams enterParams)
		{
			_diContainer = diContainer;
			GameplayRegistrations.Register(_diContainer, enterParams);
			_viewModelDIContainer = new DIContainer(_diContainer);
			GameplayViewModelRegistrations.Register(_viewModelDIContainer);

			var sceneUI = _diContainer.Resolve<IAssetInstantiateService>().GetInstance(_uiRootBinderPrefab);
			_diContainer.Resolve<UIRootView>().AttachSceneUI(sceneUI.gameObject);

			var exitSubject = new Subject<Unit>();

			sceneUI.Bind(exitSubject);

			var exitToMainMenuParams = new GameplayExitParams();

			var exitSignal = exitSubject.Select(_ => exitToMainMenuParams);

			return exitSignal;
		}
	}
}