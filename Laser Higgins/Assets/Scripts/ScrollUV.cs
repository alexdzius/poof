/*
 * ScrollUV.cs
 * Last Edited: 5/30/20
 * By: Alex Dzius
 * Desc: Handler for the background, allows for the movement as intended.
 */ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUV : MonoBehaviour
{
    // rigidbody handler for the background, to allow it to move
    Rigidbody2D go;
    void Start()
    {
       // get the component rigidbody to alow for transformations
       go = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        // get a position vector
        Vector3 position = go.transform.position;
        // set the constant velocity of the object
        go.velocity = new Vector3(0, -1, 0);
        // if a background moves outside of the camera
        if(position.y < -10)
        {
            // teleport the object up again
            go.transform.position = new Vector3(0, 20, 0);
        }
    }
}
