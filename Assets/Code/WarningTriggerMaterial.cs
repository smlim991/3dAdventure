using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningTriggerMaterial : MonoBehaviour
{
    public Material warningMat;
    Material defaultMat;
    Renderer rend;

    public GameObject player;
    void Start()
    {
        rend = GetComponent<Renderer>();
        player = GameObject.Find("Player");
        defaultMat = rend.material;
    }

    // Update is called once per frame
    void Update()
    {
        if(rend != null){
            if(GlobalVar.Invisible == true && Mathf.Abs(transform.position.y-player.transform.position.y)<1){
                rend.material = warningMat;
            }
            else{
                rend.material = defaultMat;
            }
        }
    }
}
