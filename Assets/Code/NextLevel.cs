using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public int limit;
    float xoffset,zoffset;

    public GameObject player;
    public PlayerMove playerMove;

    TransitionManager _transitionManager;

    // Start is called before the first frame update
    void Start()
    {
        player =  GameObject.Find("Player");
        playerMove = (PlayerMove)FindObjectOfType(typeof(PlayerMove));
        xoffset = transform.position.x - player.transform.position.x;
        zoffset = transform.position.z - player.transform.position.z;
        _transitionManager = FindObjectOfType<TransitionManager>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x + xoffset, transform.position.y, player.transform.position.z + zoffset);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            if(limit>GlobalVar.numKey)
            {
                _transitionManager.LoadScene("DeathScene");
            }
            else
            {
                Destroy(gameObject);
                playerMove.nextLevel += 15;
                playerMove.nextLevelScore.text = "(" + playerMove.nextLevel.ToString() + ")";
            }
        }
    }
}
