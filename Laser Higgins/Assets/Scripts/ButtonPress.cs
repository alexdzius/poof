﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public void OnPress()
    {
        GameManager.TimeSlowNeeded = true;
        GameManager.TotalLifes--;
    }
}
