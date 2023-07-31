using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Z_EulerAngles : MonoBehaviour
{


    private int Z = 0;
    void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, Z++);
    }
}
