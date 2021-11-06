using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintButton : MonoBehaviour
{
    bool enabled;
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other) {
        if(other.CompareTag("Player")) {
            if(!GlobalVar.Invisible && GlobalVar.numKey>0)
            {
                GlobalVar.Invisible = true;
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player")) {
            if(GlobalVar.Invisible)
            {
                GlobalVar.Invisible = false;
                if(GlobalVar.numKey>0) GlobalVar.numKey-=1;
            }
        }
    }
}
