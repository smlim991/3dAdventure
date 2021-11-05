using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    int speed = 100;
    

    
    void Update()
    {
        transform.Rotate(0,speed*Time.deltaTime,0, Space.World);
    }


    private void OnTriggerEnter(Collider other){
        
        if(other.CompareTag("Player")){
            GlobalVar.Score ++;
            Destroy(gameObject);
            
        }
        

        
    }

}
