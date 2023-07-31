using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C1_Position : MonoBehaviour{
    void Start()
    {
        transform.position = new Vector3(-7, 6, 0);
    }

    void Update()
    {
        //transform.position.x++; //Không truy cập trực tiếp tọa độ x được
        transform.position = new Vector3(transform.position.x+0.01f, transform.position.y, transform.position.z);
    }
}
