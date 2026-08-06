using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.Universal;

public class FruitThrowController : MonoBehaviour
{
    public static FruitThrowController Instance;

    public GameObject CurrentFruit { get; set; }
    [SerializeField] private Transform _fruitTransform;
    [SerializeField] private Transform _parentAfterThrow;
    [SerializeField] private FruitSelector _selector;


    private PlayerController _playerController;

    private Rigidbody2D _rb;
    private CircleCollider2D _circleCollider;

    public Bounds Bounds {  get; private set; }

    private const float EXTRA_WIDTH = 0.02f;
        
        
    public bool CanThrow { get; set; } = true;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
    _playerController = GetComponent<PlayerController>();
        SpawnAFruit(_selector.PickRandomFruitThrow());
    }


    private void Update()
    {
        if (UserInput.IsThrowPressed && CanThrow)
        {
            SpriteIndex index = CurrentFruit.GetComponent<SpriteIndex>();
            Quaternion rot = CurrentFruit.transform.rotation;

            GameObject go = Instantiate(FruitSelector.Instance.Fruits[index.index], CurrentFruit.transform.position, rot); 
            go.transform.SetParent(_parentAfterThrow);

            Destroy(CurrentFruit);

            CanThrow = false;
        }
    }

    public void SpawnAFruit(GameObject fruit)
    {
        // Meyveyi parent olarak _fruitTransform altına doğuruyoruz
        Debug.Log(fruit, _fruitTransform);
        GameObject go = Instantiate(fruit, _fruitTransform);

        // KESİN ÇÖZÜM: Meyvenin yerel pozisyonunu tam (0,0,0) noktasına (yani ThrowFruitTransform'un merkezine) eşitliyoruz
        go.transform.localPosition = Vector3.zero;
        go.transform.localRotation = Quaternion.identity;

        CurrentFruit = go;
        _circleCollider = CurrentFruit.GetComponent<CircleCollider2D>();
        Bounds = _circleCollider.bounds;

        _playerController.ChangeBoundary(EXTRA_WIDTH);
        _selector.PickNextFruit();
    }

}
