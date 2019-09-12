using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingInputs : MonoBehaviour
{

    float horz;
    float vert;

    Rigidbody2D rb;
    public float forceAmount;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horz = Input.GetAxisRaw("Horizontal");
        vert = Input.GetAxisRaw("Vertical");

        //Debug.Log(horz + " " + vert);

        //transform.Translate(horz*Time.deltaTime, vert*Time.deltaTime, 0);
        rb.AddForce(new Vector2(horz, vert)*forceAmount);

        if (Input.GetKey(KeyCode.G))
        {
            Debug.Log("hitting g");
            if (Input.GetKey(KeyCode.H)) {
                Debug.Log("h and g");
            }
        }
        else if (Input.GetKey(KeyCode.H))
        {
            Debug.Log("hitting h");
        }

        if (Input.GetMouseButton(0)){
            // detecting a click in general
        }

    }

    void OnMouseDown() {
        // detect when gameobject gets clicked
    }

}
