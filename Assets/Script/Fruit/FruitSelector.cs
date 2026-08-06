using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

public class FruitSelector : MonoBehaviour
{


    public static FruitSelector Instance;


    public GameObject[] Fruits; // Meyvelerin prefablarını tutan dizi
    public GameObject[] NoPyhsicFruits;
    public int HighestStartingIndex = 3;


    [SerializeField] private Image _nextFruitImage;
    [SerializeField] private Sprite[] _FruitSprites;


    public GameObject NextFruit { get; private set; } // Bir sonraki meyveyi temsil eden GameObject


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        PickNextFruit();
    }

    public GameObject PickRandomFruitThrow()
    {
        int randomIndex = Random.Range(0, HighestStartingIndex + 1); // 0 ile HighestStartingIndex arasında rastgele bir indeks seçiyoruz

        if (randomIndex < NoPyhsicFruits.Length)
        {
            GameObject randomFruit = NoPyhsicFruits[randomIndex];
            return randomFruit;
        }

        return null; // Eğer rastgele indeks, meyve dizisinin boyutunu aşarsa null döndürüyoruz
    }

    public void PickNextFruit()
    {
        int randomIndex = Random.Range(0, HighestStartingIndex + 1); // 0 ile HighestStartingIndex arasında rastgele bir indeks seçiyoruz

        if (randomIndex < Fruits.Length)
        {
            GameObject nextFruit = NoPyhsicFruits[randomIndex];
        }
    }
}