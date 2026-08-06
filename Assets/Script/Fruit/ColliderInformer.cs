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
            _hasCollided = true;
            FruitThrowController.Instance.CanThrow = true;
            FruitThrowController.Instance.SpawnAFruit(FruitSelector.Instance.NextFruit);
            FruitSelector.Instance.PickNextFruit();
            Destroy(this);
        }
    }



}
