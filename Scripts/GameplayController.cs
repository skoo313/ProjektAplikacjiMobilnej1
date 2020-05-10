using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;

    private Text scoreText;
    private int score=0;

    private void Awake()
    {
        MakeInstance();

        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        scoreText.text = "x" + score.ToString("000000");
    }

    void MakeInstance()
    {
        if (instance == null)
            instance = this;
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "x"+ score.ToString("000000");
    }

}