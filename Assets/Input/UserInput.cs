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

        // 1. PC & Gamepad Mantığı: Klavyede Space veya Gamepad butonuna BASILDIĞI AN (Dokunmatik hariç)
        bool isPCorGamepadPress = _throwAction.WasPressedThisFrame() &&
                                 !(Touchscreen.current != null && Touchscreen.current.primaryTouch.press.isPressed);

        // 2. Android / Dokunmatik Mantığı: Parmağın ekrandan KALKTIĞI AN
        // Doğrudan cihaz donanımından parmağın çekilip çekilmediğini kontrol ediyoruz.
        bool isAndroidTouchRelease = false;
        if (Touchscreen.current != null)
        {
            isAndroidTouchRelease = Touchscreen.current.primaryTouch.press.wasReleasedThisFrame;
        }

        // Parmağını ekrandan kaldırdığın an bu değer "true" olur ve tıklanmış gibi fırlatır!
        IsThrowPressed = isPCorGamepadPress || isAndroidTouchRelease;
    }
}