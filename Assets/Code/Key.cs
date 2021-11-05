using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{
    int speed = 100;
    public Text keyCountOut;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,speed*Time.deltaTime,0, Space.World);
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            GlobalVar.numKey++;
            keyCountOut.text = GlobalVar.numKey.ToString();
            Destroy(gameObject);
            
            
        }
    }
}
