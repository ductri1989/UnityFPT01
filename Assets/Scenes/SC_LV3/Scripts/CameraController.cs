using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform playerCam;
    [SerializeField] Transform lookAt;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void RotateCamera()
    {
        float camHorizontal = Input.GetAxis("MouseY");
        float camVertical = Input.GetAxis("MouseX");


    }
}
