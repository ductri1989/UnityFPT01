using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RAX_RotateAroundX : MonoBehaviour
{
    [SerializeField] Transform center;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(center.position,Vector3.right, Time.deltaTime*100);
    }
}
