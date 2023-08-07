using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGround;
    private void OnTriggerEnter(Collider other)
    {
        isGround = true;
        Debug.Log("chạm sàn");
    }
    private void OnTriggerExit(Collider other)
    {
        isGround = false;   
    }
}
