using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;
    Camera mainCam;

    public ThirdPersonCharacter player;

    public GameObject enemy;

    public bool isGrounded;

    public bool willBreak;

    public Text keyCountOut;

    public Text score;

    public Text nextLevelScore;

    public int nextLevel;

    public AudioClip collectSound;

    public AudioClip unlockSound;

    public float deathHeight = -100f;

    AudioSource _audioSource;

    TransitionManager _transitionManager;


    //float startTime;

    //public GameObject bulletPrefab;

    //public int bulletForce = 200;

    // Start is called before the first frame update
    void Start()
    {
        GlobalVar.numKey = 0;
        GlobalVar.Score = 0;
        GlobalVar.level = 0;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        player = GetComponent<ThirdPersonCharacter>();
        keyCountOut = GameObject.Find("KeyCountNum").GetComponent<Text>();
        score = GameObject.Find("ScoreNum").GetComponent<Text>();
        nextLevelScore = GameObject.Find("NextLevelScore").GetComponent<Text>();
        nextLevelScore.text = "(10)";
        nextLevel = 10;
        mainCam = Camera.main;
        _audioSource = GetComponent<AudioSource>();
        _transitionManager = FindObjectOfType<TransitionManager>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = player.m_IsGrounded;
        keyCountOut.text = GlobalVar.numKey.ToString();
        score.text = GlobalVar.Score.ToString();
        RaycastHit hit2;
        if(willBreak)
        {
            if (Physics.Raycast(transform.position, -Vector3.up, out hit2,  3))
            {
                if(hit2.transform.tag == "BreakableGlass")
                {
                    hit2.transform.tag = "Glass";
                    Destroy(hit2.transform.gameObject.GetComponent<BreakableWindow>());
                }
            }
        }
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
        if(_navMeshAgent.destination == transform.position)
        {
            _navMeshAgent.isStopped = true;
        }

        if(IsAgentOnNavMesh(gameObject) && Input.GetMouseButtonDown(0)){
            RaycastHit hit;
            if(Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit, 200)){
                if(hit.point != transform.position)
                {
                    _navMeshAgent.isStopped = false;
                }
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
        if (willBreak && (other.transform.tag == "Glass" || other.transform.tag == "BreakableGlass"))
        {
            willBreak = false;
            for(int i=0;i<GlobalVar.level;i++)
            {
                Instantiate(enemy, transform.position, Quaternion.identity);
            }
        }

        if(other.transform.tag == "Ground")
        {
            _transitionManager.LoadScene("WinningScene");
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Coin")){
            _audioSource.PlayOneShot(collectSound);
            GlobalVar.Score++;
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("Key")){
            _audioSource.PlayOneShot(unlockSound);
        }
    }
}
