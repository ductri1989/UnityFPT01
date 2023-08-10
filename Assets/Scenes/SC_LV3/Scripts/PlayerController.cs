using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] float jumpForce;
    private Vector3 playerVector;
    private Rigidbody rb;
    private bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }
    private void OnCollisionEnter(Collision collision)
    {
        canJump = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        canJump = false;
    }
    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        GetComponent<Animator>().SetFloat("Moving", new Vector3(horizontal, 0, vertical).magnitude);
        if (Input.GetKey(KeyCode.W) && rb.velocity.magnitude < maxSpeed)
            rb.AddForce(transform.forward * movementSpeed);
        if (Input.GetKey(KeyCode.S) && rb.velocity.magnitude < maxSpeed)
            rb.AddForce(-transform.forward * movementSpeed);
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
        if (Input.GetKey(KeyCode.D) && rb.velocity.magnitude < maxSpeed)
            rb.AddForce(transform.right * movementSpeed);
        if (Input.GetKey(KeyCode.A) && rb.velocity.magnitude < maxSpeed)
            rb.AddForce(-transform.right * movementSpeed);
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && canJump)
        {
            rb.AddForce(transform.up * jumpForce);
            GetComponent<Animator>().Play("Jumping Up");
        }
    }
}

