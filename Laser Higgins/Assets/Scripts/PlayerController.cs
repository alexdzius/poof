﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;
public class PlayerController : MonoBehaviour
{
  public float speed = 5f;
  // Times fired per second
  public float fireRate = 4f;
  private float timeSinceLastFire = 0f;
  public GameObject playerBullet;
  public GameObject theBlock;
  public Joystick joystick;
  public GameObject gameobject;
  public float timer = 5;
  // Start is called before the first frame update
  void Start()
  {
        Time.timeScale = GameManager.timeScaleAdjuster;
#if !UNITY_IOS
        gameobject.SetActive(false);
#endif
    }

  // Update is called once per frame
  void Update()
  {
    // movement stuff
    float yMovement = Input.GetAxisRaw("Vertical");
    float xMovement = Input.GetAxisRaw("Horizontal");
#if UNITY_IOS
        if(xMovement == 0 || yMovement == 0)
        {
            yMovement = joystick.Vertical;
            xMovement = joystick.Horizontal;
        }
#endif
        Vector2 move = new Vector2(xMovement, yMovement).normalized * Time.deltaTime * speed;
        transform.position += (Vector3)move;
        Time.timeScale = GameManager.timeScaleAdjuster;
        // shoot
        timeSinceLastFire += Time.deltaTime;
    if (Input.GetKey("space"))
    {
      if (timeSinceLastFire > 1 / fireRate)
      {
        // makes sure it doesn't fire more than once quickly
        timeSinceLastFire %= 1 / fireRate;
        Fire();
      }
    }
#if UNITY_IOS
        if(Input.touchCount > 0)
        {
            print(Input.touchCount);
            Touch touch = Input.GetTouch(0);
            if(Input.touchCount == 2)
            {
                if (timeSinceLastFire > 1 / fireRate)
                {
                    // makes sure it doesn't fire more than once quickly
                    timeSinceLastFire %= 1 / fireRate;
                    Fire();
                }
            }
            if(Input.touchCount == 3)
            {
                touch = Input.GetTouch(2);
                if(touch.phase == TouchPhase.Began && GameManager.timeLeft > 0)
                {
                    // set the timeslowneeded to true to start the decrementation process of time amount
                    GameManager.TimeSlowNeeded = true;
                    // slow down the level's sped
                    GameManager.timeScaleAdjuster = 0.25f;
                    // set the fact that the timer is occuring as true
                    GameManager.TheTimer = true;
                }
                if(touch.phase == TouchPhase.Ended || GameManager.timeLeft < 0)
                {
                    // set the bools to be confirmed that the timer is ove
                    GameManager.TimeSlowNeeded = false;
                    GameManager.TheTimer = false;
                    // set the time of the level back to ususal levels.
                    GameManager.timeScaleAdjuster = 1f;
                }
            }
        }
#endif


    }

  void OnCollisionEnter2D(Collision2D collision)
  {
    ProjectileController controller = collision.gameObject.GetComponent<ProjectileController>();
    if (controller != null)
    {
      if(controller.type == ProjectileController.Type.Enemy){
        // if it hits an enemy projectile, then decrease lives and then destroy the bullet
        GameManager.TotalLifes--;
                SoundEffectHandler.damaged = true;
        controller.Destroy();
      }
    }
    // check loop to check whether the object collided is certain powerup

    // if you have hit the health powerup
    if(collision.gameObject.tag == "HealthPUP")
    {
      // if you have collided and theres less than 3 lifes
      if(GameManager.TotalLifes < 3){
        // add a life
        GameManager.TotalLifes++;
      }
      // destroy the object afterwsrds regardless
      Destroy(collision.gameObject);
    }
    // if you have hit the firerate powerup
    if(collision.gameObject.tag == "FirePUP"){
        // destroy the collided object
        Destroy(collision.gameObject);
        // set the firerate to 6, increasing by 50%
        fireRate = 6f;
        // set a temporary delay timer for 5s
        while (timer > 0){
          timer -= Time.deltaTime;
        }
        // set time back
        timer = 5;
        // reset fire rate
        fireRate = 4f;
    }
    if(collision.gameObject.tag == "BlockPUP"){
      // destrouy colliding object
      Destroy(collision.gameObject);
      // spawn block
      Instantiate(theBlock, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), Quaternion.identity);
    }
    if(collision.gameObject.tag == "TimePUP")
        {
            // destroy colliding object
            Destroy(collision.gameObject);
            // set the timers to be beneficial
            GameManager.timeLeft = 5f;
            WaveController.wavetimer += 11f;
            WaveController.powertimer -= 11f;
        }
    if(collision.gameObject.tag == "DeathPUP")
        {
            // destroy object
            Destroy(collision.gameObject);
            // do some funky wunky
            GameManager.TotalLifes--;
            SoundEffectHandler.damaged = true;
            WaveController.wavetimer -= 5f;
        }
    if(collision.gameObject.tag == "Enemy")
        {
            // delete enemy
            Destroy(collision.gameObject);
            // remove life
            GameManager.TotalLifes--;
            SoundEffectHandler.damaged = true;
        }
    if(collision.gameObject.tag == "FreeTime")
        {
            Destroy(collision.gameObject);
            GameManager.timeLeft = 5f;
        }
  }
  // fire a plasma something
  void Fire()
  {
    GameObject bullet = Instantiate(playerBullet);
    bullet.GetComponent<ProjectileController>().type = ProjectileController.Type.Player;
    // teleport bullet to player
    bullet.transform.position = transform.position;
        SoundEffectHandler.shooted = true;
  }
}
