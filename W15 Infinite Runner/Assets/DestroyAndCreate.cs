using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAndCreate : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject ground;
    public GameObject spawnPointPos;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);

        int spawnpos = Random.Range(0, 3);
        GameObject g = Instantiate(ground, spawnPoints[spawnpos].position, Quaternion.identity);

        Vector2 groundPos = g.transform.position;
        spawnPointPos.transform.position = groundPos;

        Vector2 DestroyerPos = new Vector2(transform.position.x, groundPos.y);
        transform.position = DestroyerPos;

    }

}
