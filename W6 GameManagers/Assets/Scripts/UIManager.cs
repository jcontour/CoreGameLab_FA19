using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Laura;

    public Text scoreText;

    private void Awake()
    {
        if (Laura == null)
        {
            Laura = this;
            DontDestroyOnLoad(this);
        }
        else if (Laura != this) {
            Destroy(gameObject);
        }
    }

    public void ShowNewScore(int score) {
        scoreText.text = score.ToString();
    }

}
