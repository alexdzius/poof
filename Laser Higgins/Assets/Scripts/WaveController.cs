using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public static float wavetimer = 11;
    public static float powertimer = 33;
    private int waves = 2;
    [SerializeField] public GameObject[] enemies;
    [SerializeField] public GameObject[] powerups;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // enemy wave spawning
        wavetimer -= Time.deltaTime;
        if((int)wavetimer < 0)
        {
            GameManager.newWaveNeeded = true;
            wavetimer = 11;
            waves++;
        }
        // if wave needed
        if (GameManager.newWaveNeeded)
        {
            GameManager.newWaveNeeded = false;
            for (int i = 0; i < waves; i++)
            {
                Instantiate(enemies[Random.Range(0, enemies.Length - 1)], new Vector3((float)Random.Range(-3, 3), 8f), Quaternion.identity);  
            }
        }
        // powerup time spawning
        powertimer -= Time.deltaTime;
        if ((int)powertimer < 0)
        {
            GameManager.newPupNeeded = true;
            powertimer = 33;
        }
        // if powerup needed
        if (GameManager.newPupNeeded)
        {
            GameManager.newPupNeeded = false;
            Instantiate(powerups[Random.Range(0, powerups.Length - 1)], new Vector3((float)Random.Range(-3, 3), 8f), Quaternion.identity);
        }
    }
}
