using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffOnTheGround : MonoBehaviour
{
    public Transform[] spots;
    public GameObject coinPrefab;
    public GameObject spikePrefab;

    bool isOn;
    bool isCoin;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform pos in spots)
        {
            isOn = (Random.value > 0.5f);

            if (isOn)
            {
                isCoin = (Random.value > 0.5f);
                if (isCoin)
                {
                    GameObject c = Instantiate(coinPrefab, pos.position, Quaternion.identity);
                    c.transform.parent = gameObject.transform;
                } else
                {
                    GameObject s = Instantiate(spikePrefab, pos.position, Quaternion.identity);
                    s.transform.parent = gameObject.transform;
                }
            }
        }
    }

}
