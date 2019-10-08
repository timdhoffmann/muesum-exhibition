using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Light[] lights;

    public float lightsRange;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public void ActivateRoom()
    {
        Debug.Log("Activating lights");
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].range = lightsRange;
        }


        Debug.Log("Changing sounds");
    }

    public void DeactivateRoom() {
        for(int i = 0; i < lights.Length; i++)
        {
            lights[i].range = 0;
        }
    }
}
