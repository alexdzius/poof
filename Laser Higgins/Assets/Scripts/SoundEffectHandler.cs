using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectHandler : MonoBehaviour
{
    public AudioClip shootsound;
    public AudioClip damagesound;
    public AudioClip deathsound;
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
        if (shooted)
        {
            shooted = false;
            GetComponent<AudioSource>().clip = shootsound;
            GetComponent<AudioSource>().loop = false;
            GetComponent<AudioSource>().Play();
        }
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
