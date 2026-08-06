using UnityEngine;
using System.Collections;
using System.Collections.Generic;


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


    private void Awake()
    {
        print("Değişkenleri eşitledim");
        _bounds = _boundaries.bounds;

        _offset = transform.position.x - _fruitThrowTransform.position.x;


        _leftBound = _bounds.min.x + _offset;
        _rightBound = _bounds.max.x + _offset;


        _startingLeftBound = _leftBound;
        _startingRightBound = _rightBound;
    }

    private void Update()
    {           
        print("Oyuncu hareketini güncelliyorum");
        Vector3 newPosition = transform.position + new Vector3(UserInput.MoveInput.x * _movespeed * Time.deltaTime, 0f, 0f);
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
