using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C7_Rigidbody_velocity : MonoBehaviour
{
    void Start()
    {
        transform.position = new Vector3(-7, -3, 0);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
            GetComponent<Rigidbody>().velocity =Vector3.right;

    }
}
