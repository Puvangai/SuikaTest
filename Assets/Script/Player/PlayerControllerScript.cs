using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

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

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            NewMethod(touch.position);
        }

        if (Input.GetMouseButton(0))
        {
            NewMethod(Input.mousePosition);
        }
    }

    private void NewMethod(Vector3 pos)
    {
        Vector3 mouseWorldPosition = _mainCamera.ScreenToWorldPoint(pos);
        Vector3 newPosition = new Vector3(mouseWorldPosition.x + _offset, transform.position.y, transform.position.z);
        newPosition.x = Mathf.Clamp(newPosition.x, _leftBound, _rightBound);
        transform.position = newPosition;
    }

    public void ChangeBoundary(float extraWidth)
    {
        _leftBound = _startingLeftBound;
        _rightBound = _startingRightBound;

        _leftBound += FruitThrowController.Instance.Bounds.extents.x + extraWidth;
        _rightBound -= FruitThrowController.Instance.Bounds.extents.x + extraWidth;
    }
}