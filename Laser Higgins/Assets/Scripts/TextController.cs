/*
 * TextController.cs
 * Last Edited: 5/30/20
 * By: Alex Dzius
 * Desc: Subscript text controller, to display the right description of the slowdown based on which version it is running on.
 */ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextController : MonoBehaviour
{
    // text objects handler
    public Text[] texts;
    // Start is called before the first frame update
    void Start()
    {
        // get the first 2 text objects into an array, they are set below the canvas
        texts = GetComponentsInChildren<Text>();
        // if the version is ios, hide the pc-controlled slowdown description
#if UNITY_IOS
        Color zm = texts[1].color;
        zm.a = 0.0f;
        texts[1].color = zm;
#endif
        // if the version is everything but ios, hide the ios-controlled slowdown description 
#if !UNITY_IOS
        Color zm = texts[0].color;
        zm.a = 0.0f;
        texts[0].color = zm;
#endif
    }
}
