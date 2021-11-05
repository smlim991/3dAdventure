using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlatform : MonoBehaviour
{
    public float Offset = 2f;
    private void OnCollisionEnter(Collision other){
        IEnumerator DestroyPlane(){
            
            yield return new WaitForSeconds(Offset);
            Destroy(gameObject);
        
        }

        if(other.gameObject.CompareTag("Player")){
            StartCoroutine(DestroyPlane());
        }
    }
}
