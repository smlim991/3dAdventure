using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendManager : MonoBehaviour
{
    public GameObject[] breakableGlasses;

    public Renderer[] renderers;
    public GameObject player;
    public Material warningMat;
    Material defaultMat;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        breakableGlasses = GameObject.FindGameObjectsWithTag("BreakableGlass");
        renderers = new Renderer[breakableGlasses.Length];
        for(int i = 0; i<breakableGlasses.Length; i++)
        {
            print(breakableGlasses[i].GetComponent<Renderer>());
            renderers[i] = breakableGlasses[i].GetComponent<Renderer>();
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
