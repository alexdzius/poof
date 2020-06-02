/*
 * EnemySoundEffectHandler.cs
 * By: Alex Dzius
 * Last Edited: 6/2/30
 * Desc: Script to handle the audiosources of the enemy, to prevent conflicts with the normal sound effect handler
 */ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundEffectHandler : MonoBehaviour
{
    // set objects and static variables to access sound playing and the sound to be played as needed
    public AudioClip eshootsound;
    public AudioClip edamagesound;
    public static bool edamaged = false;
    public static bool eshooted = false;
    // Update is called once per frame
    void Update()
    {
        // if enemy has shot
        if (eshooted)
        {
            // set checking bool to false
            eshooted = false;
            // get shooting sound and prevent looping and play sound
            GetComponent<AudioSource>().clip = eshootsound;
            GetComponent<AudioSource>().loop = false;
            GetComponent<AudioSource>().Play();

            // if enemy was damaged
            if (edamaged)
            {
                // set checking bool to false
                edamaged = false;
                // get damage sound and prevent looping and play sound
                GetComponent<AudioSource>().clip = edamagesound;
                GetComponent<AudioSource>().loop = false;
                GetComponent<AudioSource>().Play();
            }
        }
    }
}
