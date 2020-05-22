/*
 * GameManager.cs
 * By: Alex Dzius
 * Last Edited: 5/20/20
 * Script to supervise the highscore, time slowdown and enemy waves.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    // highscore collecting variable
    public static int TotalScore;
    public static int TotalLifes = 3;
    // checking whether a new wave or timeslowdown of enemies is needed.
    public static bool newWaveNeeded = false;
    public static bool newPupNeeded = false;
    public static bool TimeSlowNeeded = false;
    public static bool TheTimer = false;
    public static float timeLeft = 5f;
    // static variabe to adjust the timescale for all other objects
    public static float timeScaleAdjuster = 1f;
    public static float timesinceload;
    public static float normalTime;
    private bool normaltimecheck = true;
    [SerializeField] private ActualHealthBar AccHealth;
    // Start is called before the first frame update
    void Start()
    {
        // find all objects of type gamemanager, to allow it to persist throughout changing scenes
        GameManager[] anObject = FindObjectsOfType<GameManager>();
        // if there is only one game manager
        if (anObject.Length == 1)
        {
            // then dont destroy it
            DontDestroyOnLoad(gameObject);
        }
        // if there is multiple gamemanagers
        else
        {
            // destroy the multiple
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (AccHealth == null)
        {
            AccHealth = FindObjectOfType<ActualHealthBar>();
        } 
        else
        {
            AccHealth.SetSize((float)TotalLifes / 3);
        }
        timesinceload = Time.timeSinceLevelLoad;

        if (Input.GetKey("e") && timeLeft >= 0)
        {
            TimeSlowNeeded = true;
            timeScaleAdjuster = 0.25f;
            TheTimer = true;
            print("e");
        }
        else
        {
            TimeSlowNeeded = false;
            TheTimer = false;
            timeScaleAdjuster = 1f;
            print("f");
        }



        if (normaltimecheck)
        {
            normaltimecheck = false;
            normalTime = Time.deltaTime;
        }
        // call on waves
        if (newWaveNeeded)
        {
            newWaveNeeded = false;
        }
        // if death
        if (TotalLifes == 0)
        {
            SceneManager.LoadScene("DeathScreen");
        }
    }
}
