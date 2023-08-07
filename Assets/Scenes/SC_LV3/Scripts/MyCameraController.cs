using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MyCameraController : MonoBehaviour
{
    [SerializeField]
    Transform currentCamera;

    [SerializeField]
    List<Transform>  cameraList;

    [SerializeField]
    Transform lookTarget;

    public float TopClamp = 70.0f;
    public float BottomClamp = -30.0f;

    [SerializeField]
    Vector3 rotationAngel;

    [SerializeField]
    float mouseMoveSpeed = 300;


    [SerializeField]
    Vector3 offset;

    Quaternion toRotation;

    // Update is called once per frame
    float speed = 0.01f;
    float timeCount = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        mouseMoveSpeed = 300;
        Cursor.lockState = CursorLockMode.Locked;

        currentCamera.transform.rotation = lookTarget.rotation;
    }


    void Update()
    {
        //currentCamera.LookAt(lookTarget);
    }


    private void LateUpdate()
    {
        RotateWithMouse();
        FollowTarget();
    }

    void FollowTarget()
    {
        //currentCamera.transform.position = lookTarget.position + offset;

        currentCamera.position = lookTarget.position - (currentCamera.transform.rotation * Vector3.forward) * 5;

        Debug.DrawLine(currentCamera.position, lookTarget.position - currentCamera.position,Color.red);

        //currentCamera.transform.position = lookTarget.position - currentCamera.transform.forward * 3;

        //currentCamera.transform.position = currentCamera.transform.TransformDirection(lookTarget.parent.position);
        //currentCamera.transform.RotateAround(lookTarget.position, lookTarget.up, 20 * Time.deltaTime );

        //currentCamera.transform.position = lookTarget.localPosition;

        //currentCamera.transform.position = cam1.position;
    }

    void RotateWithMouse()
    {
        rotationAngel.x -= Input.GetAxis("Mouse Y") * mouseMoveSpeed * Time.deltaTime;
        rotationAngel.y += Input.GetAxis("Mouse X") * mouseMoveSpeed * Time.deltaTime;

        rotationAngel.y = ClampAngle(rotationAngel.y, float.MinValue, float.MaxValue);
        rotationAngel.x = ClampAngle(rotationAngel.x, BottomClamp, TopClamp);

        //Cach 1
        //currentCamera.rotation = Quaternion.FromToRotation(currentCamera.forward, currentCamera.position - cameraLocation.position);

        //Cach 2
        //toRotation = Quaternion.Euler(playerLookTarget);
        //currentCamera.transform.rotation = Quaternion.Lerp(currentCamera.transform.rotation, toRotation, timeCount * speed);
        //timeCount = timeCount + Time.deltaTime;

        //Cach 3 
        //currentCamera.eulerAngles = rotationAngel;

        //Cach4
        currentCamera.transform.rotation = Quaternion.Euler(rotationAngel);

        //Test
        //lookTarget.transform.rotation = Quaternion.Euler(rotationAngel);
    }

    private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
    {
        if (lfAngle < -360f) lfAngle += 360f;
        if (lfAngle > 360f) lfAngle -= 360f;
        return Mathf.Clamp(lfAngle, lfMin, lfMax);
    }

}
