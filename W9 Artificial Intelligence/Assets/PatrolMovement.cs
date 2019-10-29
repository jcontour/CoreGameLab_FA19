using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolMovement : MonoBehaviour
{
    
    public GameObject[] patrolPoints;
    int whichPoint;
    public static bool isChasing;
    float dist;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        whichPoint = 0;
        isChasing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isChasing) {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Time.deltaTime * 3);

        }
        else {
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[whichPoint].transform.position, Time.deltaTime*3);

            dist = Vector2.Distance(transform.position, patrolPoints[whichPoint].transform.position);
            if (dist <= 0.01f) {
                whichPoint++;
                if (whichPoint >= 4) {
                    whichPoint = 0;
                }
            }
        }
    }
}
