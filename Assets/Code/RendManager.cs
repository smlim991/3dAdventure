using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendManager : MonoBehaviour
{
    public List<GameObject> breakableGlasses;

    public List<GameObject> glasses;

    public List<Renderer> renderers;
    public GameObject player;
    public Material warningMat;

    public GameObject coin;
    Material defaultMat;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        breakableGlasses = new List<GameObject>(GameObject.FindGameObjectsWithTag("BreakableGlass"));
        glasses = new List<GameObject>(GameObject.FindGameObjectsWithTag("Glass"));

        for(int i=0; i<breakableGlasses.Count; i++)
        {
            int index = Random.Range(0, breakableGlasses.Count-1);
            Destroy(breakableGlasses[index].GetComponent<BreakableWindow>());
            breakableGlasses[index].tag = "Glass";
            glasses.Add(breakableGlasses[index]);
            breakableGlasses.Remove(breakableGlasses[index]);
        }

        foreach(GameObject glass in breakableGlasses)
        {
            int index = Random.Range(0, 2);
            if(index==0)
            {
                Instantiate(coin, glass.transform.position+ new Vector3(0,0.5f,0), coin.transform.rotation);
            }
        }
        foreach(GameObject glass in glasses)
        {
            int index = Random.Range(0, 2);
            if(index==0)
            {
                Instantiate(coin, glass.transform.position + new Vector3(0,0.5f,0), coin.transform.rotation);
            }
        }

        foreach(GameObject glass in breakableGlasses)
        {
            renderers.Add(glass.GetComponent<Renderer>());
        }
        defaultMat = renderers[0].material;
    }

    // Update is called once per frame
    void Update()
    {
        foreach(GameObject glass in breakableGlasses)
        {
            if(glass!=null && Mathf.Abs(glass.transform.position.y - player.transform.position.y)<1)
            {
                Renderer renderer = glass.GetComponent<Renderer>();
                if(renderer!=null)
                {
                    if(GlobalVar.Invisible == true){
                        renderer.material = warningMat;
                    }
                    else{
                        renderer.material = defaultMat;
                    }
                }
            }
        }
    }
}
