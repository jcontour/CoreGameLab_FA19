using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple : MonoBehaviour
{

    Rigidbody2D grapple_rb;
    bool isShot;
    public GameObject grappleHoldPos;
    public GameObject player;
    Rigidbody2D player_rb;
    public float grappleLength;
    Vector2 dirToGrapple;
    public float grapplePower;

    // Start is called before the first frame update
    void Start()
    {
        grapple_rb = GetComponent<Rigidbody2D>();
        player_rb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isShot)
        {
            dirToGrapple = transform.position - player.transform.position;

            if (Vector2.Distance(transform.position, grappleHoldPos.transform.position) > grappleLength)
            {
                player_rb.AddForce(dirToGrapple * grapplePower);
            }

        } else
        {
            transform.position = grappleHoldPos.transform.position;
            PointAtMouse();
        }
        ShootGrapple();
    }

    Vector3 mouse_pos;
    Transform target;
    Vector3 grapple_pos;
    float angle;

    void PointAtMouse()
    {
        mouse_pos = Input.mousePosition;
        mouse_pos.z = 10; //The distance between the camera and object
        grapple_pos = Camera.main.WorldToScreenPoint(transform.position);
        mouse_pos.x = mouse_pos.x - grapple_pos.x;
        mouse_pos.y = mouse_pos.y - grapple_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle-90));
    }

    void ShootGrapple()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isShot = true;
            grapple_rb.velocity = transform.up*30;
        }
    }

    void StickGrapple(Vector2 pos)
    {
        grapple_rb.velocity = new Vector2(0, 0);
        grapple_rb.constraints = RigidbodyConstraints2D.FreezePosition;
        grapple_rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contact = collision.contacts[0];

        StickGrapple(contact.point);
    }

}
