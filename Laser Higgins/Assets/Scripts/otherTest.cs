/*
TEST CODE - DO NOT USE IN FINAL PRODUCT
Desc: code to test whether movement works as intended, and its impact with the "not slowed down time"
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otherTest : MonoBehaviour
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
        float yMovement = Input.GetAxisRaw("Vertical");
        float xMovement = Input.GetAxisRaw("Horizontal");
        Vector2 move = new Vector2(xMovement, yMovement).normalized * GameManager.normalTime;
        transform.position += (Vector3)move;
    }
}
