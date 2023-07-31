using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class X_EulerAngles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private int X = 0;
    void Update(){
        transform.eulerAngles = new Vector3 (X++, 0,0);
    }
}
