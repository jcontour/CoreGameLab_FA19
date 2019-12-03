using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapple2 : MonoBehaviour
{

    public GameObject grapplehook;

    Rigidbody2D rb;
    public DistanceJoint2D distJoint;

    Vector3 mousePos;
    public GameObject aim;

    public float grappleDist;


    // Start is called before the first frame update
    void Start()
    {
        distJoint = GetComponent<DistanceJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = GetMousePos();
        aim.transform.position = mousePos;

        if (Input.GetMouseButtonDown(0))
        {
            grapplehook.GetComponent<GrappleBehavior>().ShootGrapple(mousePos - transform.position);
            grappleDist = Vector2.Distance(transform.position, mousePos);

        }

    }

    Vector3 GetMousePos()
    {

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouseScreenPos = new Vector3(mouseWorldPos.x, mouseWorldPos.y, 0);
        return mouseScreenPos;
    }
}
