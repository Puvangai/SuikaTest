using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColliderInformer : MonoBehaviour
{
    public bool WasCombineIn { get; set; }

    private bool _hasCollided;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_hasCollided && !WasCombineIn)
        {
            // Meyveyi doğurmadan önce null olup olmadığını kontrol edin
            if (FruitSelector.Instance.NextFruit != null)
            {
                FruitThrowController.Instance.SpawnAFruit(FruitSelector.Instance.NextFruit);

                // Yeni meyve elinize geldikten sonra bir sonraki meyveyi seçtirin
                FruitSelector.Instance.PickNextFruit();
            }
            else
            {
                Debug.LogError("FruitSelector içindeki NextFruit henüz atanmamış (NULL)!");
            }
            _hasCollided = true;
            FruitThrowController.Instance.CanThrow = true;
           
            Destroy(this);
        }
    }



}
