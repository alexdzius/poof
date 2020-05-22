/*
ButtonPress.cs
Last Edited: 5/20/2020
By: Alex Dzius
Desc: Button Handler of anything that needs a response by the button
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonPress : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // debug option for button, responsible to test time slowdown and the removal of lives
    public void OnPress()
    {
        GameManager.TimeSlowNeeded = true;
        GameManager.TotalLifes--;
    }
    // option for start screen and death screen button, allows to return to core gameplay
    public void OnPress2()
    {
        // if pressed, load sceene
        SceneManager.LoadScene("MainScreen");
    }
    // option for death screen, to return back to the start screen if needed - start screen could contain more settings in forseeable future
    public void OnPress3()
    {
        // if pressed, load scene
        SceneManager.LoadScene("StartScreen");
    }
}
