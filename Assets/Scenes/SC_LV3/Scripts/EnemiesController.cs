using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    [SerializeField] Transform pointA;
    [SerializeField] Transform pointB;
    [SerializeField] Transform nowTarget;
    [SerializeField] float moveSpeed = 5;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        nowTarget = pointA;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (transform.position != pointA.transform.position)
        //{
        //    transform.LookAt(pointA.transform.position);
        //}
        //if(transform.position == pointA.transform.position)
        //{
        //    transform.LookAt (pointA.transform.position);
        //}

        transform.position = Vector3.MoveTowards(transform.position, nowTarget.transform.position, moveSpeed);
        transform.LookAt(nowTarget.transform.position);
        if ((pointA.transform.position - transform.position).magnitude <= 0.001)
        {
            nowTarget = pointB;
        }
        if ((pointB.transform.position - transform.position).magnitude <=0.001)
        {
            nowTarget = pointA;
        }
    }
}
