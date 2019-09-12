using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StringRecognition : MonoBehaviour
{
    string[] words = new string[4] { "CAT", "CRAB", "BIRD", "DOG"};
    public Text[] text = new Text[4];
    bool[] wordMatched = new bool[4];
    bool[] alreadyMatched = new bool[4];
    
    List<string> typedLetters = new List<string>();
    
    void Start()
    {
        for (int i = 0; i <= words.Length - 1; i++) {
            text[i].text = words[i];
            wordMatched[i] = false;
            alreadyMatched[i] = false;
        }
    }

    void letterTyped(string x) {
        typedLetters.Add(x);

        for (int i = 0; i <= typedLetters.Count - 1; i++)
        {
            for (int w = 0; w <= words.Length - 1 ; w++)
            {
                if (!alreadyMatched[w])
                {
                        
                    if (typedLetters[i] == words[w].Substring(i, 1))
                    {
                        Debug.Log("matchy " + typedLetters[i] + " " + words[w].Substring(i, 1));
                        if (i == 0) {
                            wordMatched[w] = true;
                            text[w].color = Color.red;
                            Debug.Log("you're typing " + words[w] + "!");
                        } else { 
                            if (wordMatched[w]) {
                                if (typedLetters.Count == words[w].Length) {
                                    text[w].color = Color.green;
                                    alreadyMatched[w] = true;
                                    wordMatched[w] = false;
                                    typedLetters.Clear();
                                }
                                else {
                                    Debug.Log("another letter in " + words[w] + "!");
                                }
                            } 
                        }
                    } else {
                        Debug.Log("no matchy " + typedLetters[i] + " " + words[w].Substring(i, 1));
                        wordMatched[w] = false;
                        text[w].color = Color.white;
                    }
                }
            }
        }

        bool checkIfMatches = false;

        for (int w = 0; w <= words.Length - 1; w++) {
                
            if (wordMatched[w]) {
                checkIfMatches = true;
                break;
            }
        }

        if (!checkIfMatches) {
            typedLetters.Clear();
        }
    }

    void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey && e.type == EventType.KeyDown && e.keyCode != KeyCode.None)
        {
            letterTyped(e.keyCode.ToString());
        }
    }
}
