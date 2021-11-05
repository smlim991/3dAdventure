using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningTriggerMaterial : MonoBehaviour
{
    public Material warningMat;
    Material defaultMat;
    Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
        defaultMat = rend.material;
    }

    // Update is called once per frame
    void Update()
    {
        if(rend != null){
            if(GlobalVar.Invisible == false){
                rend.material = defaultMat;
            }
            else{
                rend.material = warningMat;
            }
        }
    }
}
