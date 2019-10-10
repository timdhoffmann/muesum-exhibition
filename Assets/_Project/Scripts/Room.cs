using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public Light[] lights;

    public float lightsRange;

    private bool activating = false;

    void Start()
    {
 
    }

    void Update()
    {
        if (activating)
        {
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].range = Mathf.Lerp(lights[i].range, lightsRange, Time.deltaTime);
            }
        } else
        {
            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].range = Mathf.Lerp(lights[i].range, 0, Time.deltaTime); ;
            }
        }
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
        activating = true;        
    }

    public void DeactivateRoom()
    {
        activating = false;
    }
}
