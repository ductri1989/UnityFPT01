using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAXYZ_RotateAroundZYZ : MonoBehaviour
{
    [SerializeField] Transform center;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(center.position, new Vector3(1,1,1), Time.deltaTime * 100);
    }
}
