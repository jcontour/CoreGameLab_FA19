using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{

    int score = 0;
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void IncreaseScore() {
        score++;
        UpdateScoreText(score);
        Debug.Log(score);
    }

    public void DecreaseScore() {
        score--;
        UpdateScoreText(score);
        Debug.Log(score);
    }

    void UpdateScoreText(int s) {
        scoreText.text = s.ToString();
    }


}
