using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class T_Arrow : MonoBehaviour{

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward*1000);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
