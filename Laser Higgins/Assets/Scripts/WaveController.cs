using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public float timer = 11;
    public float powertimer = 33;
    private int waves = 2;
    [SerializeField] public GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // enemy wave spawning
        timer -= Time.deltaTime;
        if((int)timer < 0)
        {
            GameManager.newWaveNeeded = true;
            timer = 11;
            waves++;
        }
        // if wave needed
        if (GameManager.newWaveNeeded)
        {
            GameManager.newWaveNeeded = false;
            for (int i = 0; i < waves; i++)
            {
                Instantiate(enemies[Random.Range(0, enemies.Length - 1)], new Vector3((float)Random.Range(-8, 8), 8f), Quaternion.identity);  
            }
        }
        // powerup time spawning
        timer -= Time.deltaTime;
        if ((int)timer < 0)
        {
            GameManager.newPupNeeded = true;
            timer = 33;
        }
        // if powerup needed
        if (GameManager.newPupNeeded)
        {

        }
    }
}
