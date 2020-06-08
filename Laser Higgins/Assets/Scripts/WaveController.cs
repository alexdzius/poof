/*
 * WaveController.cs
 * Last Edited: 5/30/20
 * By: Alex Dzius
 * Desc: Controller for the waves of enemies and powerups, handles their spawning and the timer around them.
 */ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    // timers and wavecounters
    public static float wavetimer = 5;
    public static float powertimer = 25;
    private int waves = 2;
    // public fields to assign types of powerups and enemies
    [SerializeField] public GameObject[] enemies;
    [SerializeField] public GameObject[] powerups;

    // Update is called once per frame
    void Update()
    {
        // decrease timer as deltatime passes
        wavetimer -= Time.deltaTime;
        // once it reaches past 0
        if((int)wavetimer < 0)
        {
            // start a wave, add to the wave counter, and reset the timer
            GameManager.newWaveNeeded = true;
            wavetimer = 11;
            waves++;
        }
        // if the new wave is needed
        if (GameManager.newWaveNeeded)
        {
            // set the need to false to prevent loop
            GameManager.newWaveNeeded = false;
            // spawn additional enemies based on wave, starting from 3 enemies
            for (int i = 0; i < waves; i++)
            {
                Instantiate(enemies[Random.Range(0, 2)], new Vector3((float)Random.Range(-3, 3), 8f), Quaternion.identity);  
            }
        }
        // decrease timer as deltatime passes
        powertimer -= Time.deltaTime;
        // once it reaches past 0
        if ((int)powertimer < 0)
        {
            // start new powerup spawn and reset the timer
            GameManager.newPupNeeded = true;
            powertimer = 33;
        }
        // if powerup spawn is needed
        if (GameManager.newPupNeeded)
        {
            // set the need to be false to prevent loop
            GameManager.newPupNeeded = false;
            // spawn one powerup as needed
            Instantiate(powerups[Random.Range(0, powerups.Length - 1)], new Vector3((float)Random.Range(-3, 3), 8f), Quaternion.identity);
        }
    }
}
