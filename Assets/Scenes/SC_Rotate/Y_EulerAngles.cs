using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Y_EulerAngles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private int Y = 0;
    void Update()
    {
        transform.eulerAngles = new Vector3(0, Y++, 0);
    }
}
