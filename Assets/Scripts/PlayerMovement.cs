using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public int walkSpeed;
    public float jumpForce;
    public bool isGrounded;
    public int jumpsLeft;

    private Rigidbody2D thisRigidbody2D;
    private RaycastHit2D hitInfo;
    private Vector3 raycastLocation;

    // Use this for initialization
    void Start()
    {
        thisRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * Time.deltaTime * walkSpeed;
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Time.deltaTime * walkSpeed;
        }

        hitInfo = Physics2D.Raycast(transform.position, Vector2.down, .1f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (hitInfo.collider != null)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }


       public void Jump()
        { 
    
            if (isGrounded)
            {
                thisRigidbody2D.AddForce(transform.up * jumpForce, ForceMode2D.Force);
                isGrounded = false;
            }
        }
    }