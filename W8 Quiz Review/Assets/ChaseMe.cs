using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseMe : MonoBehaviour
{

    float speed;
    Vector3 mousePos;


    // Start is called before the first frame update
    void Start()
    {
        speed = GameManagement.Will.speed;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouseWorldPos = new Vector3(mousePos.x, mousePos.y, 0);

        transform.position = Vector2.MoveTowards(transform.position, mouseWorldPos, speed * Time.deltaTime);

    }
}
