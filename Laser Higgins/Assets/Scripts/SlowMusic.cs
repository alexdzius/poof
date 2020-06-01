using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMusic : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.TheTimer)
        {
            this.GetComponent<AudioSource>().pitch = (1.0f / 2.0f);
        }
        else
        {
            this.GetComponent<AudioSource>().pitch = 1.0f;
        }
    }
}
