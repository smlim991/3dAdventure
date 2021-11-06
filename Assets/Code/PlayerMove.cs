using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;
    Camera mainCam;

    public ThirdPersonCharacter player;

    public bool isGrounded;

    public bool willBreak;

    public Text keyCountOut;

    //float startTime;

    //public GameObject bulletPrefab;

    //public int bulletForce = 200;

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        player = GetComponent<ThirdPersonCharacter>();
        keyCountOut = GameObject.Find("KeyCountNum").GetComponent<Text>();
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = player.m_IsGrounded;
        keyCountOut.text = GlobalVar.numKey.ToString();
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
        if(IsAgentOnNavMesh(gameObject) && Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            if(Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit, 200)){
                _navMeshAgent.destination = hit.point;
            }
        }
    }

    // Reference: https://stackoverflow.com/questions/45416515/check-if-disabled-navmesh-agent-player-is-on-navmesh
    //
    float onMeshThreshold = 3;
    public bool IsAgentOnNavMesh(GameObject agentObject)
    {
        Vector3 agentPosition = agentObject.transform.position;
        NavMeshHit hit;

        // Check for nearest point on navmesh to agent, within onMeshThreshold
        if (NavMesh.SamplePosition(agentPosition, out hit, onMeshThreshold, NavMesh.AllAreas))
        {
            // Check if the positions are vertically aligned
            if (Mathf.Approximately(agentPosition.x, hit.position.x)
                && Mathf.Approximately(agentPosition.z, hit.position.z))
            {
                // Lastly, check if object is below navmesh
                return agentPosition.y >= hit.position.y;
            }
        }

        return false;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Glass" || other.transform.tag == "BreakableGlass")
        {
            willBreak = false;
        }
    }
}
