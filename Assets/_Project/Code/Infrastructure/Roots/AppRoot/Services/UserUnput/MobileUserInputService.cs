using System;
using Infrastructure.Roots.AppRoot.Services.Updater;
using UnityEngine;

namespace Infrastructure.Roots.AppRoot.Services.UserUnput
{
	public class MobileUserInputService : IUserInputService, ITick
	{
		public void Tick(float delta)
		{
			throw new NotImplementedException();
		}

		public event Action<Vector2> onMouseButtonLeftDown;
		public event Action<Vector2> onMouseButtonLeft;
		public event Action<Vector2> onMouseButtonLeftUp;
		public event Action<Vector2> onMouseButtonRightDown;
		public event Action<Vector2> onMouseButtonRight;
		public event Action<Vector2> onMouseButtonRightUp;
		public event Action onSaveGame;
		public event Action onWalkToggled;
		public event Action onSprintActivated;
		public event Action onSprintDeactivated;
		public event Action onCrouchActivated;
		public event Action onCrouchDeactivated;
		public event Action onJumpPerformed;
		public bool MovementInputDetected { get; }
		public float MovementInputDuration { get; set; }
		public Vector2 MoveComposite { get; }
		public float HorizontalMouseAxis { get; }
		public float GetMouseScrollWheel { get; }
		public Vector2 MousePosition { get; }
	}
}