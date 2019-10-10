using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : MonoBehaviour
{
    
    public Transform pivot;

    private bool fall;
    float fallAngle = 0;
    bool selected;

    [Header("Materials")]
    public Material outline;
    public Material standart;

    private void Start()
    {
        standart = GetComponent<Renderer>().material;
    }

    private void OnMouseDown()
    {
        fall = true;
    }

    private void OnMouseOver()
    { 
        selected = true;
    }

    private void OnMouseExit()
    {
        selected = false;
    }


    public void Update()
    {

        if (fall)
        {
            if (fallAngle >= Mathf.PI * 0.23f)
            {
                fall = false;
            }
            fallAngle = Mathf.Lerp(fallAngle, Mathf.PI*0.25f, Time.deltaTime);
            transform.RotateAround(pivot.position, Vector3.right, fallAngle);
        }

        if (selected)
        {
            GetComponent<Renderer>().material = outline;
            GetComponent<Renderer>().material.mainTexture = standart.mainTexture;
        }
        else
        {
            GetComponent<Renderer>().material = standart;
        }
    }



}

