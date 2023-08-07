using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Myplayer : MonoBehaviour{
    [SerializeField] float jump;
    [SerializeField] float turningSpeed;
    [SerializeField] float movementSpeed;

    private bool canJump;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision){
        canJump = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        canJump = false;
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
            rb.AddForce(Vector3.up*jump);

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 moveVector = new Vector2(horizontal, vertical);
        GetComponent<Animator>().SetFloat("Moving", moveVector.magnitude);//magnitude : lấy độ dài của vector

        if(rb.velocity.x<300 && rb.velocity.z < 300)
            rb.AddForce(horizontal * movementSpeed * Time.deltaTime, 0, vertical * movementSpeed * Time.deltaTime);//Di chuyển nhân vật

        if (Input.GetMouseButtonDown(0))
            GetComponent<Animator>().Play("DrawArrow");

        if (Input.GetMouseButtonUp(0))
            GetComponent<Animator>().Play("Recoil");
    }
}
