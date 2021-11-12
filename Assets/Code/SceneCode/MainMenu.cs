using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioClip startSound;
    AudioSource _audioSource;
    TransitionManager _transitionManager;
    private void Start(){
        _transitionManager = FindObjectOfType<TransitionManager>();
        _audioSource = GetComponent<AudioSource>();
    }
    public void play(){
        _audioSource.PlayOneShot(startSound);
        _transitionManager.LoadScene("Levels");
    }
    public void instructions(){
        _audioSource.PlayOneShot(startSound);
        _transitionManager.LoadScene("Instructions");
    }
    public void quit(){
        _audioSource.PlayOneShot(startSound);
        Application.Quit();
    }
}
