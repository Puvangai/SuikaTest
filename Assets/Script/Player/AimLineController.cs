using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AimLineController : MonoBehaviour
{
    [SerializeField] private Transform _fruitThrowTransform;
    [SerializeField] private Transform _bottomTransform;

    private LineRenderer _lineRenderer;

    private float _topPos;
    private float _bottomPos;
    private float _x;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    // UPDATE YERİNE LATEUPDATE KULLANIYORUZ
    private void LateUpdate()
    {
        // LateUpdate, diğer tüm scriptlerdeki Update metodları bittikten sonra çalışır.
        // Böylece karakterin hareketi kesin olarak bittikten sonra çizgi çizilir ve esneme olmaz.
        _x = _fruitThrowTransform.position.x;
        _topPos = _fruitThrowTransform.position.y;
        _bottomPos = _bottomTransform.position.y;

        // Z eksenini 0'a sabitlemek 2D kameralarda parlamaları/kaymaları önler
        _lineRenderer.SetPosition(0, new Vector3(_x, _topPos, 0f));
        _lineRenderer.SetPosition(1, new Vector3(_x, _bottomPos, 0f));
    }

    private void OnValidate()
    {
        _lineRenderer = GetComponent<LineRenderer>();

        // OnValidate'in çalışabilmesi için referansların atanmış olduğundan emin olmak iyidir
        if (_fruitThrowTransform != null && _bottomTransform != null && _lineRenderer != null)
        {
            _x = _fruitThrowTransform.position.x;
            _topPos = _fruitThrowTransform.position.y;
            _bottomPos = _bottomTransform.position.y;

            _lineRenderer.SetPosition(0, new Vector3(_x, _topPos, 0f));
            _lineRenderer.SetPosition(1, new Vector3(_x, _bottomPos, 0f));
        }
    }
}