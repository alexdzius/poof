using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextController : MonoBehaviour
{
    public Text[] texts;
    // Start is called before the first frame update
    void Start()
    {
        texts = GetComponentsInChildren<Text>();
#if UNITY_IOS
        Color zm = texts[1].color;
        zm.a = 0.0f;
        texts[1].color = zm;
#endif
#if !UNITY_IOS
        Color zm = texts[0].color;
        zm.a = 0.0f;
        texts[0].color = zm;
#endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
