using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C5_Dotween : MonoBehaviour{
    void Start(){
        transform.position = new Vector3(-7, 0, 0);
    }

    // Update is called once per frame
    void Update(){

        if (Input.GetKeyDown(KeyCode.Space))
            transform.DOMove(new Vector3(7, 0, 0), 2);

    }
}
