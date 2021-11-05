using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeCoin : MonoBehaviour
{
    int speed = 100;
    public Material evilMat;
    Material defaultMat;
    Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
        defaultMat = rend.material;

    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            rend.material = evilMat;
            IEnumerator Wait1(){
            
            yield return new WaitForSeconds(3f);
            Destroy(gameObject);
            
        
            }
            StartCoroutine(Wait1());
            
        }
    }
    
    void Update()
    {
        transform.Rotate(0,speed*Time.deltaTime,0, Space.World);
    }

    
    

}