using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : MonoBehaviour
{
    
    public Transform pivot;

    private bool fall;
    float fallAngle = 0;

    private void OnMouseDown()
    {
        fall = true;
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
    }

}

