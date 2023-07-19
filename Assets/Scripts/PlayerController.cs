using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEngine.Tilemaps.Tilemap;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameData GameDataObject;
    [SerializeField] GameEvent InvertGravityEvent;
    [SerializeField] GameEvent RevertGravityEvent;

    public CharacterController controller;

    Rigidbody rb;

    

    public float MoveSpeed;
    public float Walkspeed = 12f;
    public float gravity = -16f;
    public float jumpHight = 5f;

    private int JumpCount = 2;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    [SerializeField] public float JumpAntiGroundTime = 0.1f;
    [SerializeField] public float TerminalVelocity = 64.0f;

    Vector3 velocity;
    bool isGrounded;
    private float _jumpAntiGroundTimer;

    //bool Flipped = false;


    
    public float CrouchYScale = 0.5f;
    public float StartYScale;

    public float MaxSlideTime = 0.75f;
    private float SlideTime;
    public float SlideForce = 17.0f;
    private bool sliding;
    
    public float verticalInput;
    public float horizontalInput;



    public LayerMask Wall;
    public float wallrunForce;
    public float maxWallrunTime;
    public float maxWallSpeed;

    public bool isWallRight;
    public bool isWallLeft;
    public bool isWallRunning;

    public float maxWallRunCameraTilt;
    public float wallRunCameraTilt;

    public Transform orientation;




    // Start is called before the first frame update
    void Start()
    {
        StartYScale = transform.localScale.y;
        rb = GetComponent<Rigidbody>();

        //init jump anti-ground timer
        _jumpAntiGroundTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //check if grounded
        if (_jumpAntiGroundTimer > 0.0f)
        {
            //prevent extra jumps and false jumps
            isGrounded = false;
        }
        else
        {
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        }

        //zero velocity when grounded
        if (isGrounded)
        {
            velocity.y = 0.0f;
        }

        //update jump anti-ground timer
        _jumpAntiGroundTimer -= Time.deltaTime;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * MoveSpeed * Time.deltaTime);

        if (isGrounded)
        {
            this.ResetJumps();

        }

        Debug.Log(velocity.y);

        if (Input.GetButtonDown("Jump") && JumpCount > 0)
        {

            this.TakeJump();

            if (GameDataObject.IsGravityFlipped)
            {
                velocity.y = -Mathf.Sqrt(jumpHight * 2f * gravity);
            }
            else
            {
                velocity.y = Mathf.Sqrt(jumpHight * -2f * gravity);
            }
        }

        velocity.y += gravity * Time.deltaTime;

        //clamp velocity
        if (velocity.y > TerminalVelocity)
        {
            velocity.y = TerminalVelocity;
        }
        else if (velocity.y < -TerminalVelocity)
        {
            velocity.y = -TerminalVelocity;
        }

        controller.Move(velocity * Time.deltaTime);

        //old dual gravity controls
        //if (Input.GetKeyUp(KeyCode.UpArrow) && !GameDataObject.IsGravityFlipped)
        //{
        //    this.FlipGravity();
        //}

        //if (Input.GetKeyUp(KeyCode.DownArrow) && GameDataObject.IsGravityFlipped)
        //{
        //    this.FixGravity();
        //}

        //singular gravity control
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            if (GameDataObject.IsGravityFlipped)
            {
                this.FixGravity();
            }
            else
            {
                this.FlipGravity();
            }
        }

        //if (gravity == 16f)
        //{
        //    transform.eulerAngles = new Vector3(0, 0, 180);
        //}

        //if(gravity == -16f)
        //{
        //    transform.eulerAngles = new Vector3(0, 0, 0);
        //}



        verticalInput = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.LeftShift) && (verticalInput != 0)) 
        {
            StartSlide(); 
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            StopSlide();   
        }

    }


    public void ResetJumps()
    {
        this.JumpCount = 2;
    }

    public void TakeJump(int num = 1)
    {
        JumpCount -= num;

        //deny grounding
        _jumpAntiGroundTimer = JumpAntiGroundTime;
    }

    private void FixedUpdate()
    {
        if (sliding)
            SlideMove();
    }

    private void StartSlide()
    {
        sliding = true;

        transform.localScale = new Vector3(transform.localScale.x, CrouchYScale, transform.localScale.z);
        rb.AddForce(Vector3.down * 5f, ForceMode.Impulse);

        SlideTime = MaxSlideTime;

        
    }

    private void SlideMove()
    {
        

        SlideTime -= Time.deltaTime;

        if(SlideTime <= 0)
        {
            StopSlide();
        }

        MoveSpeed = SlideForce;

    }

    private void StopSlide()
    {
        transform.localScale = new Vector3(transform.localScale.x, StartYScale, transform.localScale.z);

        sliding = false;

        MoveSpeed = Walkspeed;
    }

   



    public void FlipGravity()
    {
        this.gravity = 16f;
        transform.eulerAngles = new Vector3(0, 0, 180);

        InvertGravityEvent.TriggerEvent();

    }

    public void FixGravity()
    {
        this.gravity = -16f;
        transform.eulerAngles = new Vector3(0, 0, 0);

        RevertGravityEvent.TriggerEvent();

    }

    public void NoGravity()
    {
        this.gravity = 0f;


    }
}
