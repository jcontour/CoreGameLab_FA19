using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public GameObject platform_p;
    public GameObject ball_p;
    GameObject b;

    // Start is called before the first frame update
    void Start()
    {
        for (float i = -8; i <= 8; i+=2) {
                Instantiate(platform_p, new Vector2(i, -2), Quaternion.identity);
        }

        b = Instantiate(ball_p, new Vector2(Random.Range(-4, 4) * 2, 5), Quaternion.identity);
    }

    void Update()
    {
        if (b.transform.position.y <= -6 || b.transform.position.x <= -9 || b.transform.position.x >= 9) {
            Destroy(b);
            b = Instantiate(ball_p, new Vector2(Random.Range(-4, 4)*2, 5), Quaternion.identity);
        }

    }
}
