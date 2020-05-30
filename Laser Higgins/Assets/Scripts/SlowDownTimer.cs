/*
 * SlowDownTimer.cs
 * Last Edited: 5/30/20
 * By: Alex Dzius
 * Desc: Script handler for the slodown timer, which operates the entire slowdown process and sets the timebar
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownTimer : MonoBehaviour
{
    // timebar configuration
    [SerializeField] private TimeBar timebar;

    // Update is called once per frame
    void Update()
    {
        // if the object wasnt found
        if (timebar == null)
        {
            // find the object based on type
            timebar = FindObjectOfType<TimeBar>();
        }
        // as long as timer is intended to be running
        if (GameManager.TheTimer)
        {
            // subtract the timeleft from deltatime*6, to still be fast regardless of timescale
            GameManager.timeLeft -= Time.deltaTime*6;
            // set the bar accordingly to the time left
            timebar.SetSize(GameManager.timeLeft / 5);
            // if time runs out
            if (GameManager.timeLeft < 0)
            {
                // reset timescaleadjuster to normal and disable the timer
                GameManager.timeScaleAdjuster = 1f;
                GameManager.TheTimer = false;
            }
        } 
        // if there is no timer needed to be running, but the bar isnt full
        else if (GameManager.timeLeft <= 5)
        {
            // recharge the timer slowly and set the bar accordingly
            GameManager.timeLeft += Time.deltaTime * 1 / 2;
            timebar.SetSize(GameManager.timeLeft / 5);
        }
    }

}
