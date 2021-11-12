using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScene : MonoBehaviour
{
    public void ReturnToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit1(){
        Application.Quit();
    }
}
