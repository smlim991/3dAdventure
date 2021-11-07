using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendManager : MonoBehaviour
{
    public List<GameObject> breakableGlasses;

    public List<Renderer> renderers;
    public GameObject player;
    public Material warningMat;
    Material defaultMat;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        breakableGlasses = new List<GameObject>(GameObject.FindGameObjectsWithTag("BreakableGlass"));

        for(int i=0; i<breakableGlasses.Count; i++)
        {
            int index = Random.Range(0, breakableGlasses.Count-1);
            Destroy(breakableGlasses[index].GetComponent<BreakableWindow>());
            breakableGlasses[index].tag = "Glass";
            breakableGlasses.Remove(breakableGlasses[index]);
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
        foreach(Renderer renderer in renderers)
        {
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
