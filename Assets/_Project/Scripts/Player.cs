using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Range(0, 10)]
    public float speed = 10.0F;
    [Range(0, 10)]
    public float jumpVelocity = 4.0F;
    public bool lockCursor = false;
    public bool isJumping = false;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    Rigidbody rigidBody;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rigidBody = GetComponent<Rigidbody>();
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, 1f);
    }

    void Update()
    {
        Move();
        DisplayCursor();
    }

    void Move()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;

        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        Debug.DrawRay(transform.position, -transform.up * 1.1f, Color.black);

        if (Input.GetKey(KeyCode.Space) && IsGrounded())
        {
            GetComponent<Rigidbody>().velocity = Vector3.up * jumpVelocity;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }

        if (rigidBody.velocity.y < 0)
        {
            rigidBody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rigidBody.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rigidBody.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void DisplayCursor()
    {
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
