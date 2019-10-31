using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    float vert, horz;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ColorChanger());
    }

    private void Update()
    {
        vert = Input.GetAxis("Vertical");
        horz = Input.GetAxis("Horizontal");
        transform.Translate(horz*3*Time.deltaTime, vert*3 * Time.deltaTime, 0);
    }

    IEnumerator ColorChanger()
    {
        while (true)
        {
            GetComponent<SpriteRenderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            yield return new WaitForSeconds(1);
        }


    }
}
