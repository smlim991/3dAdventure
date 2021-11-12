using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void play(){
        SceneManager.LoadScene("Levels");
    }

    public void quit(){
        Application.Quit();
    }
}
