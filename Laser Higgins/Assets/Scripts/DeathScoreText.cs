using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DeathScoreText : MonoBehaviour
{
    public Text[] endscore;
    // Start is called before the first frame update
    void Start()
    {
        endscore = GetComponentsInChildren<Text>();
        // highscore
        endscore[0].text = "Final Score: " + GameManager.TotalScore;
        // time passed since start \ TODO STILL FIX THIS AND CHECK IT
        endscore[1].text = "Total Time: " + (int)GameManager.timesinceload + " seconds";
        // reset values
        GameManager.TotalScore = 0;
        GameManager.TotalLifes = 3;
        GameManager.timeLeft = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
