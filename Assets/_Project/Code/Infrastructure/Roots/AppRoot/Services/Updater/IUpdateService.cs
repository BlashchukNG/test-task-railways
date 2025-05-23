namespace Infrastructure.Roots.AppRoot.Services.Updater
{
    public interface IUpdateService
    {
        void Add(IUpdatable updatable);
        void Remove(IUpdatable updatable);
        
        void Clear();
    }
}