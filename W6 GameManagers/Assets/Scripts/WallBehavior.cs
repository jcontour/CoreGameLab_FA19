using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBehavior : MonoBehaviour
{

    public float speed;
    public float gap;

    GameObject upperWall;
    GameObject lowerWall;

    float width;
    float height;
    Vector2 screenUnits;

    void Start()
    {
        upperWall = this.gameObject.transform.GetChild(0).gameObject;
        lowerWall = this.gameObject.transform.GetChild(1).gameObject;

        upperWall.transform.position = new Vector2(0, gap + 4);
        lowerWall.transform.position = new Vector2(0, -gap - 4);

        width = Screen.width;
        height = Screen.height;

        screenUnits = Camera.main.ScreenToWorldPoint(new Vector3(width, height, 0));

        transform.position = new Vector2(screenUnits.x + 2, Random.Range(screenUnits.y * -1, screenUnits.y));

    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x < (screenUnits.x * -1)) {
            Destroy(this.gameObject);
        }
    }
}
