using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quai : MonoBehaviour{
    [SerializeField] Transform posA, posB;
    
    void Start()
    {

    }


    void Update(){
        if(transform.position.x== posA.position.x){
            transform.DOMove(new Vector3(posB.position.x, transform.position.y, transform.position.z), 5f);
            transform.Rotate(Vector3.up, 180);
        }
        if (transform.position.x == posB.position.x) {
            transform.DOMove(new Vector3(posA.position.x, transform.position.y, transform.position.z), 5f);
            transform.Rotate(Vector3.up, 180);
        }
    }

    private void OnCollisionEnter(Collision collision){
        Debug.Log("Va chạm với GameObject : "+collision.gameObject.name);

        if (collision.gameObject.name.Equals("Plane")) {
            Debug.Log("Bắt đầu đến A");
            transform.DOMove(new Vector3(posB.position.x, transform.position.y, transform.position.z), 2.5f);
        }

        

    }
}
