using Infrastructure.DI;
using Infrastructure.Roots.GameplayScene.View;

namespace Infrastructure.Roots.GameplayScene.Registrations
{
	public static class GameplayViewModelRegistrations
	{
		public static void Register(DIContainer diContainer)
		{
			diContainer.RegisterFactory(c => new UIGameplayViewModel()).AsSingle();
			diContainer.RegisterFactory(c => new WorldGameplayViewModel()).AsSingle();
		}
	}
}