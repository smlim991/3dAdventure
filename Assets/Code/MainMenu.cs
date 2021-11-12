using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    TransitionManager _transitionManager;
    private void Start(){
        _transitionManager = FindObjectOfType<TransitionManager>();
    }
    public void play(){
        _transitionManager.LoadScene("Levels");
    }

    public void quit(){
        Application.Quit();
    }
}
