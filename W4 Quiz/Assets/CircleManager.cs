using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleManager : MonoBehaviour
{

    SpriteRenderer sr;
    AudioSource boing;
    Text score;
    int bounces = 0;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        boing = GetComponent<AudioSource>();
        score = GameObject.Find("Score").GetComponent<Text>();
        score.text = bounces.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Color c = collision.gameObject.GetComponent<SpriteRenderer>().color;
        sr.color = c;
        bounces++;
        score.text = bounces.ToString();
        boing.Play();
    }
}
