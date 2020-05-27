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
    // highscore and life collecting variables
    public static int TotalScore = 0;
    public static int TotalLifes = 3;
    // bools to supervise whether new wave of enemies or a powerup spawn is needed
    public static bool newWaveNeeded = false;
    public static bool newPupNeeded = false;
    // bools to operate the time slowdown mechamnics and allow for the time slowdown to start and stop at any given moment of charge
    public static bool TimeSlowNeeded = false;
    public static bool TheTimer = false;
    // float to be used to calculate the time left for slowdoen, and display it on the bar 
    public static float timeLeft = 5f;
    // static variabe to adjust the timescale for all other objects
    public static float timeScaleAdjuster = 1f;
    public static float timesinceload;
    // extrra float and bool fo future refence if needed to not slowdown certain objeccts -- currently not used
    public static float normalTime;
    private bool normaltimecheck = true;
    public static GameObject player;
    // variable to hold the health bar and operate the script necessary for it
    [SerializeField] private ActualHealthBar AccHealth;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        print(player);
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
        // if the healthbar object was not found, then attempt to find it based on type
        if (AccHealth == null)
        {
            AccHealth = FindObjectOfType<ActualHealthBar>();
        } 
        // if it was found
        else
        {
            // set its size based on total lifs amount ikn a serialized way
            AccHealth.SetSize((float)TotalLifes / 3);
        }
        // set the time since load variable to the actual amount of time since load, to constantly calculate the amount of seconds that have passed since begin.
        timesinceload = Time.timeSinceLevelLoad;

        // overall check if object is IOS or Desktop - these controls for desktop
        #if UNITY_EDITOR
        print("h");
            // if the slowdown button is held down, and there is slowdown time leftover
            if (Input.GetKey("e") && timeLeft >= 0)
            {
                // set the timeslowneeded to true to start the decrementation process of time amount
                TimeSlowNeeded = true;
                // slow down the level's sped
                timeScaleAdjuster = 0.25f;
                // set the fact that the timer is occuring as true
                TheTimer = true;
            }
            // if the button is not pressed anymore or time runs out
            else
            {
                // set the bools to be confirmed that the timer is ove
                TimeSlowNeeded = false;
                TheTimer = false;
                // set the time of the level back to ususal levels.
                timeScaleAdjuster = 1f;
            }
        #endif
        // CURRENTLY UNUSED: check for normaltime, to ensure that certain objects retain normal speed.
        if (normaltimecheck)
        {
            normaltimecheck = false;
            normalTime = Time.deltaTime;
        }
        // if a new wave is required, based on timer or other events
        if (newWaveNeeded)
        {
            // set the wave needed to false
            newWaveNeeded = false;
            // possibly adjust based on what type of wave is required.
        }
        // if the player has lost all thheir lives
        if (TotalLifes <= 0)
        {
            SoundEffectHandler.deathed = true;
            // load the death screen
            SceneManager.LoadScene("DeathScreen");
        }
    }
}
