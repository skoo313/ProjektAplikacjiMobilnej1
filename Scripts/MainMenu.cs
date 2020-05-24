using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void Play()
    {
        AdManager.instance.ShowAd();
        SceneManager.LoadScene(sceneBuildIndex:1);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
