using UnityEngine;
using UnityEngine.InputSystem;
public class UserInputScript : MonoBehaviour
{

    public static PlayerInput playerInput;

    public static Vector2 MoveInput { get; set; }

    public static bool IsThrowPressed { get; set; }

    private InputAction _moveAction;
    private InputAction _throwAction;

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        _moveAction = playerInput.actions["Move"];
        _throwAction = playerInput.actions["Throw"];
    }

    private void Update()
    {
        MoveInput = _moveAction.ReadValue<Vector2>();
        IsThrowPressed = _throwAction.WasPressedThisFrame();
    }

}
