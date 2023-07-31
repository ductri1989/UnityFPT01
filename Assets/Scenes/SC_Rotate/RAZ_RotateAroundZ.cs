using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAZ_RotateAroundZ : MonoBehaviour
{
    [SerializeField] Transform center;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(center.position, Vector3.forward, Time.deltaTime * 100);
    }
}
