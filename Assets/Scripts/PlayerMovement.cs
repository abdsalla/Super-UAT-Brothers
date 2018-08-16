using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Animator animController;
    public int walkSpeed;
    public float jumpForce;
    public bool isGrounded;
    public int jumpsLeft;

    private Rigidbody2D thisRigidbody2D;
    private SpriteRenderer mySR;
    private RaycastHit2D hitInfo;
    private Vector3 raycastLocation;

    // Use this for initialization
    void Start()
    {
        mySR = GetComponent<SpriteRenderer>();
        animController = GetComponent<Animator>();
        thisRigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            mySR.flipX = true;
            animController.SetInteger("Anim_State", 2);
            transform.position -= transform.right * Time.deltaTime * walkSpeed;
            
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Time.deltaTime * walkSpeed;
            animController.SetInteger("Anim_State", 2);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            mySR.flipX = false;
            animController.SetInteger("Anim_State", 0);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            animController.SetInteger("Anim_State", 0);
        }

        hitInfo = Physics2D.Raycast(transform.position + Vector3.down* .1f, Vector2.up, .1f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (hitInfo.collider.tag == "Floor")
        {
            isGrounded = true;
           
        }
        else
        {
            Debug.Log(hitInfo.collider.gameObject.tag);
            Debug.Log("In air");
            isGrounded = false;
        }
    }


       public void Jump()
        { 
    
            if (isGrounded == true)
            {
                thisRigidbody2D.AddForce(transform.up * jumpForce, ForceMode2D.Force);
                isGrounded = false;
            }
        }
    }