namespace Infrastructure.Roots.AppRoot.Services.Updater
{
	public interface ITick : IUpdatable
	{
		void Tick(float delta);
	}
}