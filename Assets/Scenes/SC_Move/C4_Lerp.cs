using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C4_Lerp : MonoBehaviour{
    void Start(){
        transform.position = new Vector3(-7, 1.5f, 0);
    }

    void Update(){
        transform.position = Vector3.Lerp(transform.position, new Vector3(7, 1.5f, 0), 0.01f);
    }
}
