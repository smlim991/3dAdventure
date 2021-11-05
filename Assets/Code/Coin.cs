using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    int speed = 100;
    public Text scoreOut;

    
    void Update()
    {
        transform.Rotate(0,speed*Time.deltaTime,0, Space.World);
    }


    private void OnTriggerEnter(Collider other){
        
        if(other.CompareTag("Player")){
            GlobalVar.Score ++;
            scoreOut.text = GlobalVar.Score.ToString();
            Destroy(gameObject);
            
        }
        

        
    }

}
