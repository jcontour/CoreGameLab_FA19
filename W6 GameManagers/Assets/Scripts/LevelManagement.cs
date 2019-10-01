using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagement : MonoBehaviour
{

    public GameObject wall_prefab;
    public float speed;

    float timer;

    EdgeCollider2D edges;

    float width;
    float height;
    Vector2 screenUnits;

    // Start is called before the first frame update
    void Start()
    {
        width = Screen.width;
        height = Screen.height;
        screenUnits = Camera.main.ScreenToWorldPoint(new Vector3(width, height, 0));

        edges = GetComponent<EdgeCollider2D>();
        Vector2[] colliderPoints;
        colliderPoints = edges.points;
        colliderPoints[0] = new Vector2(screenUnits.x, screenUnits.y);
        colliderPoints[1] = new Vector2(-screenUnits.x, screenUnits.y);
        colliderPoints[2] = new Vector2(-screenUnits.x, -screenUnits.y);
        colliderPoints[3] = new Vector2(screenUnits.x, -screenUnits.y);
        colliderPoints[4] = new Vector2(screenUnits.x, screenUnits.y);
        edges.points = colliderPoints;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= speed) {
            Instantiate(wall_prefab, new Vector2(0, 0), Quaternion.identity);
            timer = 0;
        }
    }
}
