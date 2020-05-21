using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    Rigidbody2D myRB;
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = GameManager.timeScaleAdjuster;
        print(Time.timeScale);
        if (Input.GetKeyDown("w"))
        {
            myRB.velocity = new Vector3(0, 1, 0);
        }
    }
}
