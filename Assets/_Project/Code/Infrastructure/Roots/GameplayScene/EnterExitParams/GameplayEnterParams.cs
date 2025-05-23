using Constants;
using Infrastructure.Roots.AppRoot.Abstract;

namespace Infrastructure.Roots.GameplayScene.EnterExitParams
{
	public sealed class GameplayEnterParams : BaseSceneEnterParams
	{
		public string DebugData { get; }
		
		public GameplayEnterParams(string debugData) : base(Scenes.GAMEPLAY)
		{
			DebugData = debugData;
		}
	}
}