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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if player has shot
        if (shooted)
        {
            // set to false
            shooted = false;
            // get shooting sound and prevent looping
            GetComponent<AudioSource>().clip = shootsound;
            GetComponent<AudioSource>().loop = false;
            // play sound
            GetComponent<AudioSource>().Play();
        }
        // if player was damaged
        if (damaged)
        {
            damaged = false;
            GetComponent<AudioSource>().clip = damagesound;
            GetComponent<AudioSource>().loop = false;
            GetComponent<AudioSource>().Play();
        }
        if (deathed)
        {
            deathed = false;
            GetComponent<AudioSource>().clip = deathsound;
            GetComponent<AudioSource>().loop = false;
            GetComponent<AudioSource>().Play();
        }
    }
}
