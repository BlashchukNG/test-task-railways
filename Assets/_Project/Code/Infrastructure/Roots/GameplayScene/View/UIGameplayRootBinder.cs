using Extensions;
using R3;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.Roots.GameplayScene.View
{
	public sealed class UIGameplayRootBinder : MonoBehaviour
	{
		[SerializeField] private Button _buttonQuit;

		private Subject<Unit> _exitSubject;

		private void Awake()
		{
			_buttonQuit.AddOneListener(HandleButtonQuitClicked);
		}

		public void Bind(Subject<Unit> exitSubject)
		{
			_exitSubject = exitSubject;
		}

		public void HandleButtonQuitClicked()
		{
			_exitSubject?.OnNext(Unit.Default);
		}
	}
}