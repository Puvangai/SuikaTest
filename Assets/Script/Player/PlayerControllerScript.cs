using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _movespeed = 5f;
    [SerializeField] private BoxCollider2D _boundaries;
    [SerializeField] private Transform _fruitThrowTransform;

    private Bounds _bounds;

    private float _leftBound;
    private float _rightBound;

    private float _startingLeftBound;
    private float _startingRightBound;

    private float _offset;
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;

        _bounds = _boundaries.bounds;

        _offset = transform.position.x - _fruitThrowTransform.position.x;

        _leftBound = _bounds.min.x + _offset;
        _rightBound = _bounds.max.x + _offset;

        _startingLeftBound = _leftBound;
        _startingRightBound = _rightBound;
    }

    private void Update()
    {
        Vector2 input = UserInput.MoveInput;

        // =======================================================
        // ANDROID / TOUCH
        // Parmağın ekran üzerindeki X pozisyonunu direkt takip eder.
        // =======================================================
        if (Mathf.Abs(input.x) > 1f || Mathf.Abs(input.y) > 1f)
        {
            Vector3 worldPos = _mainCamera.ScreenToWorldPoint(
                new Vector3(input.x, input.y, _mainCamera.nearClipPlane)
            );

            float targetX = Mathf.Clamp(
                worldPos.x,
                _leftBound,
                _rightBound
            );

            transform.position = new Vector3(
                targetX,
                transform.position.y,
                transform.position.z
            );
        }

        // =======================================================
        // PC / GAMEPAD
        // Input değerine göre hareket eder.
        // =======================================================
        else if (Mathf.Abs(input.x) > 0.01f)
        {
            float movement = input.x * _movespeed * Time.deltaTime;

            float targetX = transform.position.x + movement;

            targetX = Mathf.Clamp(
                targetX,
                _leftBound,
                _rightBound
            );

            transform.position = new Vector3(
                targetX,
                transform.position.y,
                transform.position.z
            );
        }
    }

    public void ChangeBoundary(float extraWidth)
    {
        _leftBound = _startingLeftBound;
        _rightBound = _startingRightBound;

        _leftBound += FruitThrowController.Instance.Bounds.extents.x + extraWidth;
        _rightBound -= FruitThrowController.Instance.Bounds.extents.x + extraWidth;
    }
}