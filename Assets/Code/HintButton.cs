using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay(Collider other) {
        if(other.CompareTag("Player") ){
            if(GlobalVar.Invisible == true){
                GlobalVar.Invisible = false;
            }
            else{
                GlobalVar.Invisible = true;

            }
        }
    }
}
