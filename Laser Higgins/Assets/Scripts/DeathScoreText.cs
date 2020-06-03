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
    public AudioClip goodmusic;
    public AudioClip badmusic;
    // Start is called before the first frame update
    void Start()
    {
        // get text objects coming from childerns in canvas and set them to array
        endscore = GetComponentsInChildren<Text>();
        endscore[0].color = Color.black;
        endscore[1].color = Color.black;
        endscore[2].color = Color.black;
        if (GameManager.TotalScore >= GameManager.CurrentHighScore)
        {
            endscore[0].text = "FIRST! with " + GameManager.TotalScore + " Points!";
            endscore[0].color = Color.green;
            endscore[1].text = "Old Highscore: " + GameManager.CurrentHighScore + " Points.";
            GameManager.CurrentHighScore = GameManager.TotalScore;
            GetComponent<AudioSource>().clip = goodmusic;
            GetComponent<AudioSource>().loop = true;
            GetComponent<AudioSource>().Play();
        }
        else
        {
            endscore[0].text = "TRY AGAIN! HS: " + GameManager.CurrentHighScore + " Points.";
            endscore[1].text = "Your score: " + GameManager.TotalScore + " Points.";
            GetComponent<AudioSource>().clip = badmusic;
            GetComponent<AudioSource>().loop = true;
            GetComponent<AudioSource>().Play();
        }
        endscore[2].text = "Survived Time: " + (int)GameManager.timesinceload + " seconds";

        // reset all values to allow for a good rreset of values
        GameManager.TotalScore = 0;
        GameManager.TotalLifes = 3;
        GameManager.timeLeft = 5f;
    }
}
