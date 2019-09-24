using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallBehavior : MonoBehaviour
{
    SpriteRenderer sr;
    AudioSource boing;

    Text score;
    int bounces = 0;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        boing = GetComponent<AudioSource>();

        score = GameObject.Find("score").GetComponent<Text>();
        score.text = bounces.ToString();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        boing.Play();
        Color c = collision.gameObject.GetComponent<SpriteRenderer>().color;
        sr.color = c;

        bounces++;
        score.text = bounces.ToString();
    }

}
