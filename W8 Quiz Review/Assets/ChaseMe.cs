using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChaseMe : MonoBehaviour
{

    float speed;
    Vector3 mousePos;
    Text countingText;
    float countdown;
    float dist;

    // Start is called before the first frame update
    void Start()
    {
        speed = GameManagement.Will.speed;
        countdown = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mouseWorldPos = new Vector3(mousePos.x, mousePos.y, 0);

        transform.position = Vector2.MoveTowards(transform.position, mouseWorldPos, speed * Time.deltaTime);

        if (dist <= 0.5f) {
            countdown -= Time.deltaTime;
            countingText.text = countdown.ToString();

            if (countdown <= 0) {

            }

        }

    }
}
