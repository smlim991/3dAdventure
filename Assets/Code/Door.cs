using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool locked = true;

    private void OnCollsionEnter(Collision other){
        if(other.gameObject.CompareTag("Player")){
            if(!locked){
                
                transform.Rotate(0,90,0);
            }
            else if (locked && GlobalVar.numKey > 0 ){
                GlobalVar.numKey--;
                transform.Rotate(0,90,0);
            }
        }
    }
    
}
