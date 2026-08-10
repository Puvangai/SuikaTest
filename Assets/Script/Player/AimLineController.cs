using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AimLineController : MonoBehaviour
{
    [SerializeField] private Transform _fruitThrowTransform;
    [SerializeField] private Transform _bottomTransform;
    [SerializeField] private Camera _camera;

    private LineRenderer _lineRenderer;

    private float _topPos;
    private float _bottomPos;
    private float _x;

    private void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();

        if (_camera == null)
        {
            _camera = Camera.main;
        }
    }

    private void LateUpdate()
    {
        // FruitThrow'ın mevcut pozisyonu
        _x = _fruitThrowTransform.position.x;
        _topPos = _fruitThrowTransform.position.y;
        _bottomPos = _bottomTransform.position.y;

        // Mouse pozisyonunu al
        Vector3 screenPosition = Input.mousePosition;

        // Ekran koordinatını World koordinatına çevir
        Vector3 worldPosition = _camera.ScreenToWorldPoint(
            new Vector3(
                screenPosition.x,
                screenPosition.y,
                Mathf.Abs(_camera.transform.position.z)
            )
        );

        worldPosition.z = 0f;

        // FruitThrow'dan mouse/parmak pozisyonuna doğru yön
        Vector3 direction =
            (worldPosition - _fruitThrowTransform.position).normalized;

        // Çizginin uzunluğu
        float lineLength = _bottomPos - _topPos;

        // Çizginin bitiş noktası
        Vector3 endPosition =
            _fruitThrowTransform.position + direction * lineLength;

        // Başlangıç noktası FruitThrow
        _lineRenderer.SetPosition(
            0,
            new Vector3(
                _fruitThrowTransform.position.x,
                _fruitThrowTransform.position.y,
                0f
            )
        );

        // Bitiş noktası mouse/parmak yönünde
        _lineRenderer.SetPosition(
            1,
            endPosition
        );
    }

    private void OnValidate()
    {
        _lineRenderer = GetComponent<LineRenderer>();

        if (_fruitThrowTransform != null &&
            _bottomTransform != null &&
            _lineRenderer != null)
        {
            _x = _fruitThrowTransform.position.x;
            _topPos = _fruitThrowTransform.position.y;
            _bottomPos = _bottomTransform.position.y;

            _lineRenderer.SetPosition(
                0,
                new Vector3(_x, _topPos, 0f)
            );

            _lineRenderer.SetPosition(
                1,
                new Vector3(_x, _bottomPos, 0f)
            );
        }
    }
}