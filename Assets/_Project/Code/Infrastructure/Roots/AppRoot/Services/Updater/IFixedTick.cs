namespace Infrastructure.Roots.AppRoot.Services.Updater
{
    public interface IFixedTick : IUpdatable
    {
        void FixedTick(float delta);
    }
}