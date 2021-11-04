using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPlatform : MonoBehaviour
{
    private void OnCollisionEnter(Collision other){
        IEnumerator DestroyPlane(){
            
            yield return new WaitForSeconds(2f);
            Destroy(gameObject);
        
        }

        if(other.gameObject.CompareTag("Player")){
            StartCoroutine(DestroyPlane());
        }
    }
}
