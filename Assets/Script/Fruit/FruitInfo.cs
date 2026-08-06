using UnityEngine;

public class FruitInfo : MonoBehaviour
{
    public int FruitIndex;
    public int PointWhenAnnihilated;
    public float FruitMass = 1f;

    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.mass = FruitMass;    
    }





}
