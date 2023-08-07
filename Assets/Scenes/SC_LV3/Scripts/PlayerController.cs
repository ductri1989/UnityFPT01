using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rigitbody;
    [SerializeField] float jumpForce;
    [SerializeField] float turningSpeed;
    [SerializeField] float movementSpeed;
    private bool canJump;
    // Start is called before the first frame update
    void Start()
    {
        rigitbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        canJump = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        canJump = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rigitbody.AddForce(Vector3.up * jumpForce);
            GetComponent<Animator>().Play("Jumping Up");
        }
        float turningLeftRight = Input.GetAxis("Mouse X") * turningSpeed;
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 moveVector = new Vector2(horizontal, vertical);
        GetComponent<Animator>().SetFloat("Moving", moveVector.magnitude);
        transform.Translate(horizontal * movementSpeed * Time.deltaTime, 0, vertical * movementSpeed * Time.deltaTime);
        transform.Rotate(0, turningLeftRight, 0);
        
        if(Input.GetMouseButtonDown(0))
        {
            GetComponent<Animator>().Play("Standing Draw Arrow");
        }
        if(Input.GetMouseButtonUp(0))
        {
            GetComponent<Animator>().Play("Standing Aim Recoil");
        }

    }


}
