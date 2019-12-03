using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleBehavior : MonoBehaviour
{
    Rigidbody2D rb;
    public bool isShot;
    public GameObject character;
    bool grapplePlaced;

    private void Start()
    {
        isShot = false;
        grapplePlaced = false;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //RetrieveGrapple();

    }

    public void ShootGrapple (Vector3 dir)
    {
        if (!isShot) {
            rb.velocity = dir*2;
            isShot = true;
        } else
        {
            isShot = false;
            RetrieveGrapple();
        }
    }

    public void RetrieveGrapple ()
    {
        character.GetComponent<Grapple2>().distJoint.connectedBody = null;
        transform.position = character.transform.position;
        grapplePlaced = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isShot) {
            grapplePlaced = true;
            character.GetComponent<Grapple2>().grappleDist = Vector2.Distance(transform.position, character.transform.position);
            character.GetComponent<Grapple2>().distJoint.connectedBody = rb;
            rb.velocity = new Vector2(0, 0);
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
