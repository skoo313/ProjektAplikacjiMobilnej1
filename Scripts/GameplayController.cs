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


        PlayerPrefs.SetInt("score", score);
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


    public void GameOver()
    {
        int endScore = score;
        bool inserted = false;
        for (int i = 0; i < 5; i++)
        {
            string tmp = "highScore" + (i + 1);

            if (PlayerPrefs.HasKey(tmp))
            {
                if(PlayerPrefs.GetInt(tmp) < endScore)
                {
                    int tmp_val = endScore;
                    endScore = PlayerPrefs.GetInt(tmp);
                    PlayerPrefs.SetInt(tmp, tmp_val);
                    inserted = true;
                }
            }
            else if(!inserted)
            {
                PlayerPrefs.SetInt(tmp, endScore);
                inserted = true;
            }
        }

    }

}