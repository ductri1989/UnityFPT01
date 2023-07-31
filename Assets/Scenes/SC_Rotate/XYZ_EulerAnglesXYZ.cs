using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XYZ_EulerAnglesXYZ : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private int X = 0;
    private int Y = 0;
    private int Z = 0;
    void Update()
    {
        transform.eulerAngles = new Vector3(X++, Y++, Z++);
    }
}
