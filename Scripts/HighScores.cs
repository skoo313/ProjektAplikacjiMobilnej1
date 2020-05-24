using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HighScores : MonoBehaviour
{
    public Text hScore1;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            string tmp_text_name= "hScore" + (i + 1);
            string tmp_record_name = "highScore" + (i + 1);

            Text text = GameObject.Find(tmp_text_name).GetComponent<Text>();
           
            if (PlayerPrefs.HasKey(tmp_record_name))
            {

                
                text.text = PlayerPrefs.GetInt(tmp_record_name).ToString();
            }
            else
            {
                text.text = "------";
            }
        }     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
