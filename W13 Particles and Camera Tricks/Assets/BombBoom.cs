using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBoom : MonoBehaviour
{
    SpriteRenderer s;
    ParticleSystem p;

    // Start is called before the first frame update
    void Start()
    {
        s = GetComponent<SpriteRenderer>();
        p = GetComponent<ParticleSystem>();
    }

    void Boom()
    {
        s.enabled = false;
        p.Play();
        Destroy(this.gameObject, p.duration);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Boom();
    }

}
