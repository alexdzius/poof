using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySoundEffectHandler : MonoBehaviour
{
    public AudioClip eshootsound;
    public AudioClip edamagesound;
    public static bool edamaged = false;
    public static bool eshooted = false;
    // Start is called before the first frame update
    void Start()
    {

    }

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
