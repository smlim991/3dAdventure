using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScene : MonoBehaviour
{
    TransitionManager _transitionManager;

    private void Start(){
        _transitionManager = FindObjectOfType<TransitionManager>();
    }
    public void ReturnToMainMenu(){
        _transitionManager.LoadScene("MainMenu");
    }

    public void Quit1(){
        Application.Quit();
    }
}
