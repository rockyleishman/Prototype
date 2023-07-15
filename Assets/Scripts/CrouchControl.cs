using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchControl : MonoBehaviour
{ 
  public CharacterController controller;

    Rigidbody rb;

    public float MoveSpeed;
    public float Walkspeed = 10f;
    public float gravity = -16f;
    public float jumpHight = 5f;

    private int JumpCount = 2;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;


    bool Flipped = false;


    public float CrouchSpeed = 5.0f;
    public float CrouchYScale = 0.5f;
    public float StartYScale;

    


    public MovementState state;
    

    // Start is called before the first frame update
    void Start()
    {
        StartYScale = transform.localScale.y;
    }


    public enum MovementState
    {
        moving,
        air,
        crouching,

    }


    private void StateHandler()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            state = MovementState.crouching;
            MoveSpeed = CrouchSpeed;
        }

        if (isGrounded)
        {
            state = MovementState.moving;
            MoveSpeed = Walkspeed;
        }
        else
        {
            state = MovementState.air;
        }
    }


    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * MoveSpeed * Time.deltaTime);

        if (isGrounded)
        {
            this.ResetJumps();

        }


        if (Input.GetButtonDown("Jump") && JumpCount > 0)
        {

            this.TakeJump();

            velocity.y = Mathf.Sqrt(jumpHight * -2f * gravity);


        }


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);



        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            this.FlipGravity();
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            this.FixGravity();
        }


        if (Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            transform.localScale = new Vector3(transform.localScale.x, CrouchYScale, transform.localScale.z);
            rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            transform.localScale = new Vector3(transform.localScale.x, StartYScale, transform.localScale.z);
            
        }



        StateHandler();


    }


    public void ResetJumps()
    {
        this.JumpCount = 2;
    }

    public void TakeJump(int num = 1)
    {
        JumpCount -= num;
    }

    public void FlipGravity()
    {
        this.gravity = 16f;

        transform.Rotate(0, 0, 180);
        transform.Translate(0, 2, 0);
       
    }

    public void FixGravity()
    {
        this.gravity = -16f;

        transform.Rotate(0, 0, 180);
        transform.Translate(0, 2, 0);
       

    }


   

}