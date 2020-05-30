/*
 * theBlock.cs
 * Last Edited: 5/30/20
 * By: Alex Dzius
 * Desc: handler for the block from the block powerup, acts as a temporary shield to the player
 */ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class theBlock : MonoBehaviour
{
    // timer to delay blocks destruction
    private float timer = 5f;

    // Update is called once per frame
    void Update()
    {
        // countdown timer
        timer -= Time.deltaTime;
        // if timer is past 0 seconds
        if (timer <= 0) 
        {
            // destroy block
            Destroy(gameObject);
        }
    }
    // if block collides with something
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if its not the player
        if(collision.gameObject.tag != "Player")
        {
            // if it hits an enemy
            if (collision.gameObject.tag == "Enemy")
            {
                // add 1 to score
                GameManager.TotalScore++;
            }
            // destroy collided object regardless
            Destroy(collision.gameObject); 
        }
    }
}
