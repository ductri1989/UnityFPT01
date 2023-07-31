using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MenuTeacher : MonoBehaviour{
    [MenuItem("Teacher/Menu 1")]
    static void onMenu1(){
        Debug.Log("Doing Something... in menu 1");
    }



    [MenuItem("Teacher/Menu 2")]
    static void onMenu2(){
        Debug.Log("Doing Something... in menu 2");
    }
}
