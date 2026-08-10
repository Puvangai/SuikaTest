using UnityEngine;
using UnityEngine.InputSystem;

public class UserInput : MonoBehaviour
{
    public static PlayerInput PlayerInput;

    public static Vector2 MoveInput { get; set; }
    public static bool IsThrowPressed { get; set; }

    private InputAction _moveAction;
    private InputAction _throwAction;

    private void Awake()
    {
        PlayerInput = GetComponent<PlayerInput>();

        _moveAction = PlayerInput.actions["Move"];
        _throwAction = PlayerInput.actions["Throw"];
    }

    private void Update()
    {

        MoveInput = _moveAction.ReadValue<Vector2>();

        if (Touchscreen.current != null)
        {
            var touch = Touchscreen.current.primaryTouch;


            if (touch.press.isPressed)
            {
                MoveInput = touch.position.ReadValue();
            }
        }

        bool isPCorGamepadPress =
            _throwAction.WasPressedThisFrame() &&
            !(Touchscreen.current != null &&
              Touchscreen.current.primaryTouch.press.isPressed);

        bool isAndroidTouchRelease = false;

        if (Touchscreen.current != null)
        {
            isAndroidTouchRelease =
                Touchscreen.current.primaryTouch.press
                .wasReleasedThisFrame;
        }


        IsThrowPressed =
            isPCorGamepadPress ||
            isAndroidTouchRelease;
    }
}