using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavmeshBaker : MonoBehaviour {

    public NavMeshSurface[] surfaces;
    public Transform[] objectsToRotate;

    public PlayerMove player;

    // Use this for initialization
    void Update ()
    {
        if(player.willBreak)
        {
            for (int i = 0; i < surfaces.Length; i++) 
            {
                surfaces [i].RemoveData();
            }
        }
        else
        {
            surfaces =  (NavMeshSurface[]) GameObject.FindObjectsOfType (typeof(NavMeshSurface));

            for (int j = 0; j < objectsToRotate.Length; j++)
            {
                objectsToRotate [j].localRotation = Quaternion.Euler (new Vector3 (0, Random.Range (0, 360), 0));
            }

            for (int i = 0; i < surfaces.Length; i++) 
            {
                surfaces [i].BuildNavMesh ();
            }
        }
    }

}