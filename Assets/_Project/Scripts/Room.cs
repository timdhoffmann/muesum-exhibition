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

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ActivateRoom();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            DeactivateRoom();
        }
    }

    public void ActivateRoom()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].range = lightsRange;
        }

        
    }

    public void DeactivateRoom() {
        for(int i = 0; i < lights.Length; i++)
        {
            lights[i].range = 0;
        }
    }
}
