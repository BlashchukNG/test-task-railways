using System;
using Infrastructure.Roots.AppRoot.Services.Updater;
using UnityEngine;

namespace Infrastructure.Roots.AppRoot.Services.UserUnput
{
	public class PCUserInputService : IUserInputService, ITick
	{
		public event Action<Vector2> onMouseButtonLeftDown = v => { };
		public event Action<Vector2> onMouseButtonLeft = v => { };
		public event Action<Vector2> onMouseButtonLeftUp = v => { };
		public event Action<Vector2> onMouseButtonRightDown = v => { };
		public event Action<Vector2> onMouseButtonRight = v => { };
		public event Action<Vector2> onMouseButtonRightUp = v => { };
		public event Action onSaveGame = () => { };
		public event Action onWalkToggled = () => { };
		public event Action onSprintActivated = () => { };
		public event Action onSprintDeactivated = () => { };
		public event Action onCrouchActivated = () => { };
		public event Action onCrouchDeactivated = () => { };
		public event Action onJumpPerformed = () => { };

		public bool MovementInputDetected { get; private set; }
		public float MovementInputDuration { get; set; }

		public Vector2 MoveComposite
		{
			get
			{
				var composite = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
				MovementInputDetected = composite.magnitude > 0;
				return composite;
			}
		}

		public Vector2 MousePosition => Input.mousePosition;
		public float HorizontalMouseAxis => Input.GetMouseButton(1) ? Input.GetAxis("Mouse X") : 0;
		public float GetMouseScrollWheel => Input.GetAxis("Mouse ScrollWheel");

		public void Tick(float delta)
		{
			if (Input.GetMouseButtonDown(0)) onMouseButtonLeftDown.Invoke(Input.mousePosition);
			if (Input.GetMouseButton(0)) onMouseButtonLeft.Invoke(Input.mousePosition);
			if (Input.GetMouseButtonUp(0)) onMouseButtonLeftUp.Invoke(Input.mousePosition);

			if (Input.GetMouseButtonDown(1)) onMouseButtonRightDown.Invoke(Input.mousePosition);
			if (Input.GetMouseButton(1)) onMouseButtonRight.Invoke(Input.mousePosition);
			if (Input.GetMouseButtonUp(1)) onMouseButtonRightUp.Invoke(Input.mousePosition);

			if (Input.GetKeyDown(KeyCode.Space)) onJumpPerformed.Invoke();

			if (Input.GetKeyDown(KeyCode.X)) onWalkToggled.Invoke();

			if (Input.GetKeyDown(KeyCode.LeftShift)) onSprintActivated.Invoke();
			if (Input.GetKeyUp(KeyCode.LeftShift)) onSprintDeactivated.Invoke();

			if (Input.GetKeyDown(KeyCode.LeftControl)) onCrouchActivated.Invoke();
			if (Input.GetKeyUp(KeyCode.LeftControl)) onCrouchDeactivated.Invoke();
			
			if(Input.GetKeyDown(KeyCode.F5)) onSaveGame.Invoke();
		}
	}
}