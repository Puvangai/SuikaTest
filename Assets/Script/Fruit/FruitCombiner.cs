using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class FruitCombiner : MonoBehaviour
{

    private int _layerIndex;

    private FruitInfo _info;

    private void Awake()
    {
        _layerIndex = gameObject.layer;
        _info = GetComponent<FruitInfo>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == _layerIndex)
        {
            FruitInfo info = collision.gameObject.GetComponent<FruitInfo>();
            if (info != null)
            {
                if (info.FruitIndex == _info.FruitIndex)
                {
                    int thisID = gameObject.GetInstanceID();
                    int otherID = collision.gameObject.GetInstanceID();

                    if (thisID > otherID)
                    {
                        GameManager.Instance.IncreaseScore(info. PointWhenAnnihilated);

                        if (_info.FruitIndex == FruitSelector.Instance.Fruits.Length - 1)
                        {
                            Destroy(collision.gameObject);
                            Destroy(gameObject);
                        }

                        else
                        {
                            Vector3 middlePosition = (transform.position + collision.transform.position) / 2f;
                            GameObject go =  Instantiate(SpawnCombinedFruit(_info.FruitIndex), GameManager.Instance.transform);
                            go.transform.position = middlePosition;

                            ColliderInformer informer = go.GetComponent<ColliderInformer>();
                            if (informer != null)
                            {
                                informer.WasCombineIn = true;
                            }

                            Destroy(collision.gameObject);
                            Destroy(gameObject);
                        }
                    }
                }
            }
        }
    }

    private GameObject SpawnCombinedFruit(int index) 
    {
        GameObject go = FruitSelector.Instance.Fruits[index + 1];
        return go;
    }
}
