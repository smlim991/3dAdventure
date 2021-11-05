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

    //float startTime;

    //public GameObject bulletPrefab;

    //public int bulletForce = 200;

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
        /*if(Input.GetMouseButtonDown(0)){
            startTime = Time.time;
        }
        else if(Input.GetMouseButtonUp(0)){
            if(Time.time - startTime <.2f){
                RaycastHit hit;
                if(Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition),out hit, 200)){
                    _navMeshAgent.destination = hit.point;
                }
                else{
                    RaycastHit hit;
                    if(Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit, 200)){
                        transform.LookAt(hit.point);
                        GameObject newBullet = Instantiate(bulletPrefab, spawnPoint.position, transform.rotation);
                        newBullet.GetComponent<Rigidbody>().AddForce(transform.forward *bulletForce);
                    }
                }
            }
        }*/
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
