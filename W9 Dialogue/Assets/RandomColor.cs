using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{

    Color[] colors = new Color[] { Color.red, Color.blue, Color.green };

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine( AutoColorChange() );
        StartCoroutine(ThreeColorChange());
    }

    IEnumerator ThreeColorChange()
    {
        foreach (Color c in colors)
        {
            GetComponent<SpriteRenderer>().material.color = c;
            yield return new WaitForSeconds(1);
        }

        // SAME THING
        //for (int i = 0; i < colors.Length; i++)
        //{
        //    GetComponent<SpriteRenderer>().material.color = colors[i];
        //    yield return new WaitForSeconds(1);
        //}
    }

    IEnumerator AutoColorChange()
    {
        while (true)
        {
            GetComponent<SpriteRenderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            yield return new WaitForSeconds(1);
        }
    }

}
