using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    float maxVol = .3f;
    public AudioClip[] clips;
    private float fadeSpeed = .2f;
    private AudioSource[] audioSources;
    private int trackIndex = 0;
    void Awake(){
        if(FindObjectsOfType<TransitionManager>().Length >1){
            Destroy(gameObject);
        }
        else{
            DontDestroyOnLoad(gameObject);
            audioSources = GetComponents<AudioSource>();
        }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode){
        StopAllCoroutines();
        StartCoroutine(FadeMusic(audioSources[trackIndex],audioSources[trackIndex = 1-trackIndex], scene.buildIndex));

    }
    private IEnumerator FadeMusic(AudioSource fadeIn, AudioSource fadeOut, int buildIndex){
        fadeIn.clip = clips[buildIndex];
        fadeIn.Play();

        float t =0;
        while (t <1){
            fadeIn.volume = Mathf.SmoothStep(0, maxVol, t);
            fadeOut.volume = Mathf.SmoothStep(maxVol, 0, t);
            t += Time.deltaTime * fadeSpeed;
            yield return null;
        }
        fadeOut.Stop();
    }
    void OnEnable(){
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    void OnDisable(){
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
