/*
ActualHealthBar.cs
Last Edited: 5/30/2020
By: Alex Dzius
Desc: Health Bar handler to allow for the health bar to be adjusted and be equivalent to thhe amount of lives present
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualHealthBar : MonoBehaviour
{
    // set transform object 
    private Transform bar;
    // Start is called before the first frame update
    private void Start()
    {
        // find transform object based on name, it will represent the "center object" in the bar
        bar = transform.Find("ActualBar");
    }
    public void SetSize(float sizeNormalized)
    {
        // if bar size adjustment is needed, set the scale of the bar to the normalized length of the value passed in
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }
}
