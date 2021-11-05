using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerMove : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;
    Camera mainCam;

    public ThirdPersonCharacter player;

    public bool isGrounded;

    public bool willBreak;

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        player = GetComponent<ThirdPersonCharacter>();
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(willBreak)
        {
            print("break");
        }
        isGrounded = player.m_IsGrounded;
        if(!isGrounded)
        {
            _navMeshAgent.speed = 3;
        }
        else
        {
            _navMeshAgent.speed = 5;
        }

        if(!isGrounded && willBreak)
        {
            _navMeshAgent.enabled = false;
        }
        else{
            _navMeshAgent.enabled = true;
        }
        if(Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            if(Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit, 200)){
                _navMeshAgent.destination = hit.point;
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Glass" || other.transform.tag == "BreakableGlass")
        {
            willBreak = false;
        }
    }
}
