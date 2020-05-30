/*
 * Boundaries.cs
 * Last Edited: 5/30/20
 * By: Alex Dzius
 * Desc: Boundaries handler, to limit the player's movement to the field of view of the camera
 */ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    // camera object handler
    public Camera MainCamera;
    // variables to handle the screen and object dimensions
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    // Use this for initialization
    void Start()
    {
        // set the screenbounds to the max view of the camera, to set the bounds
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        // set width and height to the half length of such, to allow for direct measurement of width and height
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; 
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; 
    }

    // LateUpdate in order to have it occur after all movement has occured
    void LateUpdate()
    {
        // get a vector to set transfor.position of object
        Vector3 viewPos = transform.position;
        // clamp the maximum extend of the players position to the aforementioned screen width including object parameters
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x - objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        // assign the max extend to the transform position
        transform.position = viewPos;
    }
}
