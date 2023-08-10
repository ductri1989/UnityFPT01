using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T_Myplayer : MonoBehaviour{
    [SerializeField] Transform camPlayer;
    [SerializeField] Transform beginArrow;
    [SerializeField] float jump;
    [SerializeField] float turningSpeed;
    [SerializeField] float movementSpeed;
    [SerializeField] bool isControlPlayer;
    [SerializeField] GameObject arrow;


    private bool canJump;
    private Rigidbody rb;
    void Start()
    {
        lastTimeAttack = 0;
        isControlPlayer = true;
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision){
        canJump = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        canJump = false;
    }


    private long lastTimeAttack;
    void Update(){
        if (isControlPlayer == false)
            return;

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
            rb.AddForce(Vector3.up * jump);

        if (Input.GetMouseButtonDown(0) && DateTimeUtil.currentUtcTimeMilliseconds-lastTimeAttack>1000)
            GetComponent<Animator>().Play("DrawArrow");

        if (Input.GetMouseButtonUp(0) && DateTimeUtil.currentUtcTimeMilliseconds-lastTimeAttack>1000){
            GetComponent<Animator>().Play("Recoil");
            lastTimeAttack = DateTimeUtil.currentUtcTimeMilliseconds;

            Instantiate(arrow, beginArrow.position, Camera.main.transform.rotation);
        }


        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 moveVector = new Vector2(horizontal, vertical);
        GetComponent<Animator>().SetFloat("Moving", moveVector.magnitude);//magnitude : lấy độ dài của vector

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        if (Input.GetKey(KeyCode.W) && rb.velocity.z < movementSpeed)
            rb.AddForce(transform.forward * movementSpeed);
        if (Input.GetKey(KeyCode.S) && rb.velocity.z > -movementSpeed)
            rb.AddForce(-transform.forward * movementSpeed);
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);

        if (Input.GetKey(KeyCode.D) && rb.velocity.x < movementSpeed)
            rb.AddForce(transform.right * movementSpeed);
        if (Input.GetKey(KeyCode.A) && rb.velocity.x > -movementSpeed)
            rb.AddForce(-transform.right * movementSpeed);
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);

        float camHorizontal = Input.GetAxis("Mouse X") * turningSpeed * Time.deltaTime;
        transform.Rotate(0, camHorizontal, 0);//Xoay nhân vật theo con chuột

        float camVertical = Input.GetAxis("Mouse Y") * turningSpeed * Time.deltaTime;
        Camera.main.transform.position = camPlayer.position;
        Camera.main.transform.localEulerAngles = new Vector3(Camera.main.transform.localEulerAngles.x, transform.localEulerAngles.y, 0);//Xoay Y của Camera
        Camera.main.transform.Rotate(-camVertical, 0, 0);//Xoay X của camera
        StartCoroutine(DestroyArrow());
    }

    IEnumerator DestroyArrow()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.arrow);
    }
}
