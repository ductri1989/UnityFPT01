using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C6_Rigidbody_AddForce : MonoBehaviour{
    void Start(){
        transform.position = new Vector3(-7, -1.5f, 0);
    }

    void Update(){

        if (Input.GetKeyDown(KeyCode.Space))
            GetComponent<Rigidbody>().AddForce(Vector3.right* 20);

    }
}
