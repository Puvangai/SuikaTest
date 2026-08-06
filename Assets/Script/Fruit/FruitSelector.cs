using UnityEngine;
using UnityEngine.UI;

public class FruitSelector : MonoBehaviour
{
    public static FruitSelector Instance;

    public GameObject[] Fruits;         // Fizikli meyveler
    public GameObject[] NoPyhsicFruits; // Fiziksiz meyveler (Elde tutulan)
    public int HighestStartingIndex = 3;

    [SerializeField] private Image _nextFruitImage;
    [SerializeField] private Sprite[] _FruitSprites;

    public GameObject NextFruit { get; private set; } // UI'da gösterilen ve SIRADAKİ gelecek meyve

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        // Oyuna başlarken kuyruğa ilk "Sonraki Meyve"yi seçip resmi yüklüyoruz
        PickNextFruit();
    }

    /// <summary>
    /// Sıradaki meyveyi ele verir ve UI paneli için YENİ bir sonraki meyve seçip resmini günceller.
    /// </summary>
    public GameObject GetNextFruitAndRollNew()
    {
        // 1. Şu an UI'da görünen meyveyi ele vermek üzere saklıyoruz
        GameObject fruitToSpawn = NextFruit;

        // 2. UI için yeni bir sonraki meyve seçip görseli güncelliyoruz
        PickNextFruit();

        // 3. Sakladığımız meyveyi ele doğurulması için döndürüyoruz
        return fruitToSpawn;
    }

    /// <summary>
    /// Rastgele yeni bir "NextFruit" seçer ve UI üzerindeki Image'i günceller.
    /// </summary>
    public void PickNextFruit()
    {
        if (NoPyhsicFruits == null || NoPyhsicFruits.Length == 0) return;

        int maxIndex = Mathf.Min(HighestStartingIndex + 1, NoPyhsicFruits.Length);
        int randomIndex = Random.Range(0, maxIndex);

        // Sıradaki meyveyi belirliyoruz
        NextFruit = NoPyhsicFruits[randomIndex];

        // UI üzerindeki görseli sıradaki meyvenin sprite'ı yapıyoruz
        if (_nextFruitImage != null && _FruitSprites != null && randomIndex < _FruitSprites.Length)
        {
            _nextFruitImage.sprite = _FruitSprites[randomIndex];
        }
    }
}