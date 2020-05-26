using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class continusAudio : MonoBehaviour
{
    public AudioClip loop;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!this.GetComponent<AudioSource>().isPlaying)
        {
            this.GetComponent<AudioSource>().clip = loop;
            this.GetComponent<AudioSource>().loop = true;
            this.GetComponent<AudioSource>().Play();
        }
    }
}
