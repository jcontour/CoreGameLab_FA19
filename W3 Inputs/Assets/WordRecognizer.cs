using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordRecognizer : MonoBehaviour
{
    List<string> letters = new List<string>();
    string[] mywords = new string[] { "BEANS", "CHICKEN", "EGGS", "CHEESE", "TOMATO" } ;
    string myword;
    public Text text;

    void Start()
    {
        myword = mywords[Random.Range(0,mywords.Length-1)];
        text.text = myword;
    }

    void OnGUI()
    {
        if (Event.current.type == EventType.KeyDown && Event.current.keyCode != KeyCode.None) {
            Debug.Log("Current detected event: " + Event.current);
            letters.Add(Event.current.keyCode.ToString());

            for (int i = 0; i <= letters.Count - 1; i++) {
                if (letters[i] == myword.Substring(i, 1))
                {
                    Debug.Log("yay you typing ");
                    text.color = Color.green;

                    if (letters.Count == myword.Length) {
                        Debug.Log("you typed " + myword + ". yay you are a typer woohoo");
                        //text.fontStyle = FontStyle.Bold;
                        letters.Clear();
                        myword = mywords[Random.Range(0, mywords.Length - 1)];
                        text.text = myword;
                        text.color = Color.white;
                    }
                }
                else {
                    Debug.Log("boo you suck");
                    letters.Clear();
                    text.color = Color.red;
                }
            }
        }
    }
}
