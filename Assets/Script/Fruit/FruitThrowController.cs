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


    private PlayerController playerController;

    private Rigidbody2D _rb;
    private CircleCollider2D _circleCollider;

    public Bounds Bounds {  get; private set; }

    private const float EXTRA_WIDTH = 0.02f;
        
        
    public bool CanTHrow { get; set; } = true;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
    
    }

    public void SpawnFruit(GameObject fruit)
    {
         GameObject go = Instantiate(fruit, _fruitTransform);
        CurrentFruit = go;
        _circleCollider = CurrentFruit.GetComponent<CircleCollider2D>();
        Bounds = _circleCollider.bounds;
    }

}
