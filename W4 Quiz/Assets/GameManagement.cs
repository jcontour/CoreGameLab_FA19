using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{

    public GameObject platform_prefab;
    public GameObject ball_prefab;

    float width;
    float height;
    Vector2 screenUnits;

    GameObject b;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = -8; i <= 8; i+=2) {
            Instantiate(platform_prefab, new Vector2( i , -2), Quaternion.identity);
        }

        width = Screen.width;
        height = Screen.height;

        screenUnits = Camera.main.ScreenToWorldPoint(new Vector3(width, height, 0));
        Debug.Log(screenUnits);

        b = Instantiate(ball_prefab, new Vector2(Random.Range(-8, 8), 5), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {

        if (b.transform.position.x <= screenUnits.x * -1 || b.transform.position.x >= screenUnits.x || b.transform.position.y <= screenUnits.y * -1)
        {
            Destroy(b);
            b = Instantiate(ball_prefab, new Vector2(Random.Range(-8, 8), 5), Quaternion.identity);
        }
    }
}
