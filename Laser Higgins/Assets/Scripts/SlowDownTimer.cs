using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownTimer : MonoBehaviour
{
    // timebar configuration
    [SerializeField] private HealthBar healthbar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.TheTimer)
        {
            GameManager.timeLeft -= Time.deltaTime;
            healthbar.SetSize(GameManager.timeLeft / 5);
            print(GameManager.timeLeft / 5);
            if (GameManager.timeLeft < 0)
            {
                GameManager.timeScaleAdjuster = 1f;
                GameManager.TheTimer = false;
                GameManager.TheTimerOver = true;
                print("hi");
            }
        } 
        else if (GameManager.timeLeft <= 5)
        {
            GameManager.timeLeft += Time.deltaTime * 1 / 2;
            healthbar.SetSize(GameManager.timeLeft / 5);
        }
    }

}
