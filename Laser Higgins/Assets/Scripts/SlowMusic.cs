/*
 * SlowMusic.cs
 * By: Kyle J.
 * Last Edited: 6/1/20
 * Desc: slows down time when needed
 */ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMusic : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // if slowdown is active
        if(GameManager.TheTimer)
        {
            // change pitch
            this.GetComponent<AudioSource>().pitch = (1.0f / 2.0f);
        }
        // if not, reset pitch to normal
        else
        {
            this.GetComponent<AudioSource>().pitch = 1.0f;
        }
    }
}
