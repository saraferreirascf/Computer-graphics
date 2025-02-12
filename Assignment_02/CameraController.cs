﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public float panSpeed = 20f;

    // Update is called once per frame
    void Update(){

        Vector3 pos = transform.position;
        
        if(Input.GetKey("w")){
            pos.z += panSpeed * Time.deltaTime;
        }

        if(Input.GetKey("s")){
            pos.z -= panSpeed * Time.deltaTime;
        }

        if(Input.GetKey("d")){
            pos.x += panSpeed * Time.deltaTime;
        }

        if(Input.GetKey("a")){
            pos.x -= panSpeed * Time.deltaTime;
        }

        transform.position = pos;
    }
}


  