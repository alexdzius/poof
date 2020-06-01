/*
DeathScoreText.cs
Last Edited: 5/20/20
By: Alex Dzius
Desc: Death Screen Handler, allows for the displaying of the text on the last scene, and allow for restart of the game
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DeathScoreText : MonoBehaviour
{
    // text array for better handling of text objects
    public Text[] endscore;
    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.TotalScore >= GameManager.HighScore)
        {
            GameManager.HighScore = GameManager.TotalScore;
        }
        // get text objects coming from childerns in canvas and set them to array
        endscore = GetComponentsInChildren<Text>();
        // set highscore based on total score achieved by all players so far
        endscore[0].text = "Final Score: " + GameManager.TotalScore;
        // set the time survived from timesinceload, which represents the time since the loading of the game scene, which is set here
        endscore[1].text = "Total Time: " + (int)GameManager.timesinceload + " seconds";
        // highscore
        endscore[2].text = "Highscore: " + GameManager.HighScore;
        // reset all values to allow for a good rreset of values
        GameManager.TotalScore = 0;
        GameManager.TotalLifes = 3;
        GameManager.timeLeft = 5f;
    }
}
