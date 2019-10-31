using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{

    public string[] sentences;
    public Text dialogueText;

    int index;
    public float typingSpeed;

    public GameObject continueButton;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        dialogueText.text = "";
        StartCoroutine(TextTyper());
        continueButton.SetActive(false);

        //dialogueText.text = sentences[index];
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogueText.text == sentences[index])
        {
            continueButton.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Return))
            {
                ContinueDialogue();
            }
        } else
        {
            continueButton.SetActive(false);
        }
        

        // BORING NO TYPING DIALOGUE
        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    index++;
        //    if (index > sentences.Length - 1)
        //    {
        //        index = 0;
        //    }
        //    dialogueText.text = sentences[index];
        //}
    }

    public void ContinueDialogue()
    {
        index++;
        if (index > sentences.Length - 1)
        {
            index = 0;
        }
        dialogueText.text = "";
        StartCoroutine(TextTyper());
    }

    IEnumerator TextTyper()
    {
        foreach(char c in sentences[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
