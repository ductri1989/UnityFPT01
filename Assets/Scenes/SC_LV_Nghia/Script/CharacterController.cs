using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
     [SerializeField]bool haveJumpInput;
    public Rigidbody myBody;
    public float jumpForce;
     GroundCheck _groundCheck;
    Vector3 moveDir;
    [SerializeField] float moveSpeed;
    Vector3 velocity ;
    Animator _animator;
    float animationBend;
    public float turninSpeed;
    public Transform cameraTransform;
    
    private void Awake()
    {
        _groundCheck = GetComponentInChildren<GroundCheck>();
        myBody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }
    void Start()
    {      
    }

    // Update is called once per frame
    void Update()
    {
        
        PlayerInput();
       // Debug.Log("Anim " + animationBend);
        animationBend = moveDir.magnitude;
        PlayerRotation();
    //    PlayerRotation2();
       

    }
    private void FixedUpdate()
    {
        PlayerJump();
        //PlayerMove();
        PlayerMove();
    }

    void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_groundCheck.isGround == true)
            {
                haveJumpInput = true;
            }
        }
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
         moveDir= new Vector3(horizontal, 0,vertical);
        moveDir = Quaternion.AngleAxis(Camera.main.transform.rotation.eulerAngles.y, Vector3.up) * moveDir;
        moveDir.Normalize();
        //Debug.Log(animationBend);
    }
    void PlayerJump()
    {
        if(haveJumpInput) 
        { 
            myBody.AddForce(Vector3.up * jumpForce);
            haveJumpInput = false;
        }     
    }
    void PlayerMove()
    {
       // float horizontal = Input.GetAxis("Horizontal");
        velocity.x = moveDir.x * moveSpeed;
        velocity.y = myBody.velocity.y;
        velocity.z = moveDir.z * moveSpeed;
        //Vector3 velocity = moveDir * moveSpeed;
        myBody.velocity = velocity;
     
        if (velocity.magnitude >= 0)
        {
            _animator.SetFloat("Moving", animationBend);
        }
        if(velocity.magnitude == 0) 
        {
            _animator.SetFloat("Moving", animationBend);
        }
        //transform.rotation = Vector3.Lerp(Vector3.zero, moveDir, 0.5f);
        //transform.Rotate(0, horizontal * turninSpeed, 0);
      
       
    }

    void PlayerRotation()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (horizontal != 0 || vertical != 0)
        {
            Quaternion angle = Quaternion.LookRotation(moveDir, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, angle, 0.1f );
        }
    }

    void PlayerRotation2()
    {
        //if(player)
        transform.rotation = Quaternion.Euler(0, cameraTransform.eulerAngles.y, 0);
    }


}
