using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class EnemyControl : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target;                                    // target to aim for

        public GameObject player;

        public Rigidbody rigidBody;
        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

	        agent.updateRotation = false;
	        agent.updatePosition = true;
            player = GameObject.FindGameObjectWithTag("Player");
            target = player.transform;
            rigidBody = player.GetComponent<Rigidbody>();
        }


        private void Update()
        {
            if(Mathf.Abs(transform.position.y - player.transform.position.y)>1)
            {
                Destroy(gameObject);
            }

            if(GetComponent<UnityEngine.AI.NavMeshAgent>().enabled)
            {
                if (target != null)
                    agent.SetDestination(target.position);
                try {
                    if (agent.remainingDistance > agent.stoppingDistance)
                        character.Move(agent.desiredVelocity, false, false);
                    else
                    character.Move(Vector3.zero, false, false);
                }
                catch (Exception e) {
                    print("error");
                }
            }
        }

        private void FixedUpdate()
        {
            if(Vector3.Distance(transform.position, player.transform.position)<1)
            {
                rigidBody.AddForce(10*(player.transform.position - transform.position), ForceMode.Impulse);
            }
        }


        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}
