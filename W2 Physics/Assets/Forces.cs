using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forces : MonoBehaviour
{

    Rigidbody2D rb;
    public float forceamount;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(Random.Range(-1.0f,1.0f), 1) * forceamount, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "ColorChangingPlatform")
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }

        //Debug.Log("collision!! " + collision.gameObject.name);
        

        // same thing
        //SpriteRenderer sr = collision.gameObject.GetComponent<SpriteRenderer>();
        //sr.color = Color.red;

    }
}
