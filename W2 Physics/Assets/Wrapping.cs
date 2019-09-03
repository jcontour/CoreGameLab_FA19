using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrapping : MonoBehaviour
{

    float max_x;
    float max_y;

    // Start is called before the first frame update
    void Start()
    {
        max_x = 10.5f;
        max_y = 5.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= max_x) {
            transform.position = new Vector2(-max_x + 0.1f, transform.position.y);
        }
        if (transform.position.x < -max_x) {
            transform.position = new Vector2(max_x, transform.position.y);
        }
        if (transform.position.y >= max_y) {
            transform.position = new Vector2(transform.position.x, -max_y + 0.1f);
        }
        if (transform.position.y < -max_y) {
            transform.position = new Vector2(transform.position.x, max_y);
        }
    }
}
