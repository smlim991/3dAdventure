using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    float distance;
    NavMeshAgent _navMeshAgent;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(LookForPlayer());
    }

    IEnumerator LookForPlayer(){
        while(true){
            distance = Vector3.Distance(transform.position, player.transform.position);
            
            yield return new WaitForSeconds(.5f);
            if(distance<3){
                _navMeshAgent.destination = player.transform.position;
            }
            
        }
    }

    private void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("Bullet")){
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
