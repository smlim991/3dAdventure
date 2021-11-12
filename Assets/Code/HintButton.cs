using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintButton : MonoBehaviour
{
    bool enabled;
    Vector3 scale;
    // Start is called before the first frame update

    void Start()
    {
        scale = transform.localScale;
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
                transform.localScale = new Vector3(transform.localScale.x, scale.y/5, transform.localScale.z);
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Player")) {
            if(GlobalVar.Invisible)
            {
                GlobalVar.Invisible = false;
                transform.localScale = scale;
                if(GlobalVar.numKey>0) GlobalVar.numKey-=1;
            }
        }
    }
}
