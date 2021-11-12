using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public int limit;
    float xoffset,zoffset;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player =  GameObject.Find("Player");
        xoffset = transform.position.x - player.transform.position.x;
        zoffset = transform.position.z - player.transform.position.z;
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
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            else
            {
                Destroy(gameObject);
            }
            
        }
    }
}
