using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10.0F;
    public bool lockCursor = false;
    public bool isJumping = false;
    public bool isGrounded = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Room")
        {
            Debug.Log("Entered room");
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Room")
        {
            isGrounded = false;
        }
    }

    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;

        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 150);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            lockCursor = !lockCursor;
            if (lockCursor)
            {
                Debug.Log("NO_LOCK");
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = true;
            }
            else
            {
                Debug.Log("LOCK");
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }


}
