using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue1 : MonoBehaviour
{
    public Text textDisplay;
    public string[] sentences;
    int index;
    public float typingSpeed;

    public GameObject button;

    void Start()
    {
        index = 0;
        StartCoroutine(Type());
    }

    private void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            button.SetActive(true);
        }
    }

    // a coroutine is like a function
    // but all the code inside it doesn't
    // need to run all at once
    IEnumerator Type()
    {
        // for example:
        // in order to delay code 2 seconds
        // yield return new WaitForSeconds(2);
        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

    }

    public void NextSentence()
    {

        button.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            button.SetActive(false);
        }
    }
}
