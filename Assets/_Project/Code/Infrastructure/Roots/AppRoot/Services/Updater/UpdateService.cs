using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure.Roots.AppRoot.Services.Updater
{
	public sealed class UpdateService : MonoBehaviour, IUpdateService
	{
		private readonly List<IUpdatable> _updatables = new(205);
		private readonly List<ITick> _ticks = new(100);
		private readonly List<IFixedTick> _fixedTicks = new(100);
		private readonly List<ILateTick> _lateTicks = new(5);

		public void Add(IUpdatable updatable)
		{
			_updatables.Add(updatable);
			if (updatable is ITick tick) _ticks.Add(tick);
			if (updatable is IFixedTick fixedTick) _fixedTicks.Add(fixedTick);
			if (updatable is ILateTick lateTick) _lateTicks.Add(lateTick);
		}

		public void Remove(IUpdatable updatable)
		{
			_updatables.Remove(updatable);
			if (updatable is ITick tick) _ticks.Add(tick);
			if (updatable is IFixedTick fixedTick) _fixedTicks.Add(fixedTick);
			if (updatable is ILateTick lateTick) _lateTicks.Add(lateTick);
		}

		public void Clear()
		{
			foreach (var updatable in _updatables)
				if (updatable != null)
					Destroy((updatable as MonoBehaviour).gameObject);

			_ticks.Clear();
			_fixedTicks.Clear();
			_lateTicks.Clear();
			_updatables.Clear();
		}

		private void Update()
		{
			var delta = Time.deltaTime;
			var count = _ticks.Count;
			for (var i = 0; i < count; i++) _ticks[i].Tick(delta);
		}

		private void FixedUpdate()
		{
			var delta = Time.deltaTime;
			var count = _fixedTicks.Count;
			for (var i = 0; i < count; i++) _fixedTicks[i].FixedTick(delta);
		}

		private void LateUpdate()
		{
			var delta = Time.deltaTime;
			var count = _lateTicks.Count;
			for (var i = 0; i < count; i++) _lateTicks[i].LateTick(delta);
		}
	}
}