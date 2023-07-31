using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAY_RotateAroundY : MonoBehaviour
{
    [SerializeField] Transform center;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(center.position, Vector3.up, Time.deltaTime * 200);
    }
}
