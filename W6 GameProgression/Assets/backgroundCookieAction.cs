using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundCookieAction : MonoBehaviour
{

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(Random.Range(-6, 6), 6);

        float randomVel = Random.Range(-5, 5);
        rb.velocity = new Vector2(randomVel, randomVel);

        float randomSize = Random.Range(0.05f, 0.25f);
        transform.localScale = new Vector2(randomSize, randomSize);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -6) {
            Destroy(this.gameObject);
        }
    }
}
