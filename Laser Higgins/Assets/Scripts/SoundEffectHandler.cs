/*
 * SoundEffectHandler.cs
 * Last Edited: 5/30/20
 * By: Alex Dzius
 * Desc: sound effect handler, to allow for sounds to be played at correct times
 */ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectHandler : MonoBehaviour
{
    // audio clip holders
    public AudioClip shootsound;
    public AudioClip damagesound;
    public AudioClip deathsound;
    // static bools that control when each sound effect is intended to play
    public static bool shooted = false;
    public static bool damaged = false;
    public static bool deathed = false;

    // Update is called once per frame
    void Update()
    {
        // if player has shot
        if (shooted)
        {
            // set checking bool to false
            shooted = false;
            // get shooting sound and prevent looping and play sound
            GetComponent<AudioSource>().clip = shootsound;
            GetComponent<AudioSource>().loop = false;
            GetComponent<AudioSource>().Play();
        }
        // if player was damaged
        if (damaged)
        {
            // set checking bool to false
            damaged = false;
            // get damage sound and prevent looping and play sound
            GetComponent<AudioSource>().clip = damagesound;
            GetComponent<AudioSource>().loop = false;
            GetComponent<AudioSource>().Play();
        }
        // if player has died
        if (deathed)
        {
            // set checking bool to false
            deathed = false;
            // get death sound and prevent looping and play sound
            GetComponent<AudioSource>().clip = deathsound;
            GetComponent<AudioSource>().loop = false;
            GetComponent<AudioSource>().Play();
        }
    }
}
