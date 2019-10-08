using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10.0F;
    public bool lockCursor = false;
    public bool isJumping = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void OnCollisionEnter(Collision collision)
    {

        Debug.Log("Entered: " + collision.gameObject.name + " tag: " + collision.gameObject.tag);
        
        if (collision.gameObject.tag == ("Room"))
        {
            collision.gameObject.GetComponent<MeshRenderer>().materials[0].color = Color.blue;
        }

    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, 1f);
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Room")
        {
            collision.gameObject.GetComponent<MeshRenderer>().materials[0].color = Color.white;
        }
    }

    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;

        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        Debug.DrawRay(transform.position, -transform.up * 1.1f, Color.black);
        Debug.Log(IsGrounded());

        if (Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 150);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            lockCursor = !lockCursor;
            if (lockCursor)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }


}
