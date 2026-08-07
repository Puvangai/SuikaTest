using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _movespeed = 5f;
    [SerializeField] private float _smoothSpeed = 15f; // Mobilde dokunmatik takip yumuşaklığı
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

        // 1. MOBİL (DOKUNMATİK): Input System'den piksel koordinatı geliyorsa (1'den büyük değerler)
        if (Mathf.Abs(input.x) > 1f || Mathf.Abs(input.y) > 1f)
        {
            // Parmağın ekrandaki koordinatını oyun dünyasına çeviriyoruz
            Vector3 worldPos = _mainCamera.ScreenToWorldPoint(new Vector3(input.x, input.y, _mainCamera.nearClipPlane));

            // Senin önceden hesapladığın dinamik sınırlar içinde tutuyoruz
            float targetX = Mathf.Clamp(worldPos.x, _leftBound, _rightBound);

            // Lerp ile mevcut pozisyondan hedef pozisyona pürüzsüz geçiş
            float smoothX = Mathf.Lerp(transform.position.x, targetX, Time.deltaTime * _smoothSpeed);

            transform.position = new Vector3(smoothX, transform.position.y, transform.position.z);
        }
        // 2. PC / KLAVYE (A-D veya Sol-Sağ Tuşları): Gelen girdi -1 ile 1 arasındaysa
        else if (input.x != 0)
        {
            Vector3 newPosition = transform.position + new Vector3(input.x * _movespeed * Time.deltaTime, 0f, 0f);
            newPosition.x = Mathf.Clamp(newPosition.x, _leftBound, _rightBound);

            transform.position = newPosition;
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