using Infrastructure.Roots.GameplayScene.EnterExitParams;

namespace Infrastructure.Roots.AppRoot.Services.SceneLoader
{
	public interface ISceneLoaderService
	{
		void LoadGameplay(GameplayEnterParams enterParams = null);
	}
}