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
        if (healthbar == null)
        {
            healthbar = FindObjectOfType<HealthBar>();
        }
        if (GameManager.TheTimer)
        {
            GameManager.timeLeft -= Time.deltaTime*6;
            healthbar.SetSize(GameManager.timeLeft / 5);
            print(Time.timeScale);
            if (GameManager.timeLeft < 0)
            {
                GameManager.timeScaleAdjuster = 1f;
                GameManager.TheTimer = false;
            }
        } 
        else if (GameManager.timeLeft <= 5)
        {
            GameManager.timeLeft += Time.deltaTime * 1 / 2;
            healthbar.SetSize(GameManager.timeLeft / 5);
        }
    }

}
