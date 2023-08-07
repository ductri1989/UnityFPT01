using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform cam1;
    [SerializeField] GameObject myPlayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cam1.transform.position;
        //cam1.LookAt(myPlayer.transform.position);
        cam1.transform.position = new Vector3(myPlayer.transform.position.x, myPlayer.transform.position.y + 2, myPlayer.transform.position.z - 4);
        Camera.main.transform.LookAt(myPlayer.transform.position);
    }
}
