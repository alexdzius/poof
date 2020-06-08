/*
HealthBar.cs
Last Edited: 5/20/20
By: Alex Dzius
Desc: Time Bar handler, adjusting the size of the bar inside the bars border where it is needed based on current amount of time left of the slodown
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeBar : MonoBehaviour
{
    // set transform object
    private Transform bar;
    // Start is called before the first frame update
    private void Start()
    {
        // find object of name bar, to reassign the needed bar object where needed
        bar = transform.Find("Bar");
    }
    // function to set the size of the bar depending on the value incoming
    public void SetSize(float sizeNormalized)
    {
        bar.localScale = new Vector3(sizeNormalized, 1f);
    }
}
