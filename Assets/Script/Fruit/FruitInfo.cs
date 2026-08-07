using UnityEngine;

public class FruitInfo : MonoBehaviour
{
    public int FruitIndex;
    public int PointWhenAnnihilated;
    public float FruitMass = 1f;

    // 2D oyunlar için Rigidbody2D kullanıyoruz
    private Rigidbody2D _rb;

    private void Awake()
    {
        // 1. 2D Fizik bileşenini alıyoruz
        _rb = GetComponent<Rigidbody2D>();

        // 2. Güvenlik Kontrolü: Eğer obje üzerinde Rigidbody2D varsa kütleyi ayarla.
        // Bu sayede fiziksiz bir meyveye (NoPyhsicFruit) eklense bile oyun patlamaz.
        if (_rb != null)
        {
            _rb.mass = FruitMass;
        }
    }
}