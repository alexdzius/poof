/*
 * PlayerController.cs
 * Last Edited: 5/30/20
 * By: Marvin Chan, Alex Dzius
 * Desc: Handler script for the player, involves movement, functions and powerup handling altogether. Works both on IOS and PC.
 */ 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;
public class PlayerController : MonoBehaviour
{
  public float speed = 5f;
  // Times fired per second
  public float fireRate = 4f;
  private float timeSinceLastFire = 0f;
  // GameObjects to handle the bullets, block, and joystick
  public GameObject playerBullet;
  public GameObject theBlock;
  public Joystick joystick;
  public GameObject joystickGO;
  // animation control
  private Animator animator;
  // timer and vector3 direction, to allow for certain things to operate
  public float timer = 5;
  Vector3 currentDirection;
  // Start is called before the first frame update
  void Start()
  {
    // set the time to the timescaleadjuster, which at start is 1
    Time.timeScale = GameManager.timeScaleAdjuster;
        // get animator
        animator = GetComponent<Animator>();
    // if the project is running not on ios
#if !UNITY_IOS
    // disable the joystick object
    joystickGO.SetActive(false);
#endif
  }

  // Update is called once per frame
  void Update()
  {
    // movement stuff
    float yMovement = Input.GetAxisRaw("Vertical");
    float xMovement = Input.GetAxisRaw("Horizontal");
    // if project is on IOS, detect movement from joystick
#if UNITY_IOS
        if(xMovement == 0 || yMovement == 0)
        {
            yMovement = joystick.Vertical;
            xMovement = joystick.Horizontal;
        }
#endif
    currentDirection = new Vector2(xMovement, yMovement).normalized * speed;
    transform.position += (Vector3)currentDirection * Time.deltaTime;
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
        // if program is running on ios
#if UNITY_IOS
        if(Input.touchCount > 0)
        {
            // get touch struct to account for touches
            Touch touch = Input.GetTouch(0);
            // if there is 2 touch inputs
            if(Input.touchCount == 2)
            {
                // run the firing script and handler
                if (timeSinceLastFire > 1 / fireRate)
                {
                    // makes sure it doesn't fire more than once quickly
                    timeSinceLastFire %= 1 / fireRate;
                    Fire();
                }
            }
            // if there is 3 touch inputs
            if(Input.touchCount == 3)
            {
                // set the touch struct to hold as long as at least 2 fingers are on
                touch = Input.GetTouch(2);
                // if touching has began, and theres time left for slowdown, then start slowdown
                if(touch.phase == TouchPhase.Began && GameManager.timeLeft > 0)
                {
                    // set the timeslowneeded to true to start the decrementation process of time amount
                    GameManager.TimeSlowNeeded = true;
                    // slow down the level's sped
                    GameManager.timeScaleAdjuster = 0.25f;
                    // set the fact that the timer is occuring as true
                    GameManager.TheTimer = true;
                }
                // if touching ends or time runs out, end slowdown
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
      if (controller.type == ProjectileController.Type.Enemy)
      {
        // if it hits an enemy projectile, then decrease lives and then destroy the bullet
        GameManager.TotalLifes--;
        SoundEffectHandler.damaged = true;
        controller.Destroy();
        animator.SetBool("phit", true);
        StartCoroutine(ExecuteAfterTime(1));

      }
    }
    // if you have hit the health powerup
    if (collision.gameObject.tag == "HealthPUP")
    {
      // if you have collided and theres less than 3 lifes
      if (GameManager.TotalLifes < 3)
      {
        // add a life
        GameManager.TotalLifes++;
      }
      // destroy the object afterwsrds regardless
      Destroy(collision.gameObject);
    }
    // if you have hit the firerate powerup
    if (collision.gameObject.tag == "FirePUP")
    {
      // destroy the collided object
      Destroy(collision.gameObject);
      // set the firerate to 6, increasing by 50%
      fireRate = 6f;
      // set a temporary delay timer for 5s
      while (timer > 0)
      {
        timer -= Time.deltaTime;
      }
      // set time back
      timer = 5;
      // reset fire rate
      fireRate = 4f;
    }
    if (collision.gameObject.tag == "BlockPUP")
    {
      // destrouy colliding object
      Destroy(collision.gameObject);
      // spawn block
      Instantiate(theBlock, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), Quaternion.identity);
    }
    if (collision.gameObject.tag == "TimePUP")
    {
      // destroy colliding object
      Destroy(collision.gameObject);
      // set the timers to be beneficial
      GameManager.timeLeft = 5f;
      WaveController.wavetimer += 11f;
      WaveController.powertimer -= 11f;
    }
    if (collision.gameObject.tag == "DeathPUP")
    {
      // destroy object
      Destroy(collision.gameObject);
      // decrease lives, decrease wave time and put sound on damage
      GameManager.TotalLifes--;
      SoundEffectHandler.damaged = true;
      WaveController.wavetimer -= 5f;
            animator.SetBool("phit", true);
            StartCoroutine(ExecuteAfterTime(1));
        }
    if (collision.gameObject.tag == "Enemy")
    {
      // delete enemy
      Destroy(collision.gameObject);
      // remove life
      GameManager.TotalLifes--;
      SoundEffectHandler.damaged = true;
            animator.SetBool("phit", true);
            StartCoroutine(ExecuteAfterTime(1));
        }
    if (collision.gameObject.tag == "FreeTime")
    {
      // delete the collided object, and add free time
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

  public Vector3 getCurrentDirection()
  {
    return currentDirection;
  }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        animator.SetBool("phit", false);
    }
}
