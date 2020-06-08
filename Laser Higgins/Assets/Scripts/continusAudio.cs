/*
 * continiousAudio.cs
 * Last Edited: 5/30/20
 * By: Kyle J.
 * Desc: Handler for the Intro sequence of the ingame music.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class continusAudio : MonoBehaviour
{
    // audioclip object handler
    public AudioClip loop;
    // Update is called once per frame
    void Update()
    {
        // if the intro sequence stops playing
        if (!this.GetComponent<AudioSource>().isPlaying)
        {
            // set the audiosources clip to the looping part
            this.GetComponent<AudioSource>().clip = loop;
            // set the looping to true, and then play the looping sequence after the intro
            this.GetComponent<AudioSource>().loop = true;
            this.GetComponent<AudioSource>().Play();
        }
    }
}
