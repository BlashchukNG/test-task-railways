using System;

namespace Infrastructure.DI
{
	public abstract class DIEntry : IDisposable
	{
		protected DIContainer Container { get; }
		protected bool IsSingle { get; set; }

		protected DIEntry()
		{
		}

		protected DIEntry(DIContainer container)
		{
			Container = container;
		}

		public T Resolve<T>()
		{
			return ((DIEntry<T>)this).Resolve();
		}

		public DIEntry AsSingle()
		{
			IsSingle = true;
			return this;
		}

		public abstract void Dispose();
	}

	public sealed class DIEntry<T> : DIEntry
	{
		private Func<DIContainer, T> Factory { get; }
		private T _instance;
		private IDisposable _disposableInstance;

		public DIEntry(DIContainer container, Func<DIContainer, T> factory) : base(container)
		{
			Factory = factory;
		}

		public DIEntry(T value)
		{
			_instance = value;

			if (_instance is IDisposable disposableInstance)
			{
				_disposableInstance = disposableInstance;
			}

			IsSingle = true;
		}

		public T Resolve()
		{
			if (IsSingle)
			{
				if (_instance == null)
				{
					_instance = Factory(Container);

					if (_instance is IDisposable disposableInstance)
					{
						_disposableInstance = disposableInstance;
					}
				}

				return _instance;
			}

			return Factory(Container);
		}

		public override void Dispose()
		{
			_disposableInstance?.Dispose();
		}
	}
}