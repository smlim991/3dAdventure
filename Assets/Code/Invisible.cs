using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invisible : MonoBehaviour
{
    
    void Update()
    {
        if(GlobalVar.Invisible == false){
            gameObject.GetComponent<Renderer>().enabled = false;
        }
        else{
            gameObject.GetComponent<Renderer>().enabled = true;
        }
    }
}
