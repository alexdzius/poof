/*
 * ProjectileController.cs
 * Last Edited: 5/30/20
 * By: Marvin Chan
 * Desc: Projectile handler, to handle its operations, destruction and operation
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
  public enum Type
  {
    Player,
    Enemy
  }

  public Type type;
  public float speed = 7f;
  private float outOfBounds = 20f;
  public bool targetPlayer = false;
  public GameObject player;
  private Vector3 direction;
  public float boundsNearPlayer = 2.5f;

  public ProjectileController()
  {

  }
  // Start is called before the first frame update
  void Start()
  {
    // calculate direction it needs to move in linearly
    if (targetPlayer)
    {
      direction = (Vector3.MoveTowards(transform.position, player.transform.position, 1) - transform.position).normalized;
    }
    // 1/3 chance of shooting a leading projectile
    if (type == Type.Enemy && Random.value < 0.33f)
    {
      // projectile leading that doesn't work because player is too speedy
      /*       Vector3 playerPos = player.transform.position;
            Vector3 currentPos = transform.position;
            Vector3 playerMove = player.GetComponent<PlayerController>().getCurrentDirection();
            float time = Vector3.Distance(currentPos, playerPos) / speed;
            // estimate approximate position of player to target and hit if player continues moving on current trajectory
            playerPos += time * playerMove * player.GetComponent<PlayerController>().speed;
            print(playerPos);
            direction = (Vector3.MoveTowards(currentPos, playerPos, speed * Time.deltaTime) - transform.position).normalized;
            targetPlayer = true; */
      // direction vector aimed at random position within 2 units of the player
      direction = (Vector3.MoveTowards(transform.position, player.transform.position + new Vector3(Random.Range(-boundsNearPlayer, boundsNearPlayer), Random.Range(-boundsNearPlayer, boundsNearPlayer), 0), 1) - transform.position).normalized;
      targetPlayer = true;
    }
  }

  // Update is called once per frame
  void Update()
  {
    // if player projectile then move upwards
    if (type == Type.Player)
    {
      transform.position += (Vector3)new Vector2(0, speed * Time.deltaTime);
    }
    // if enemy projectile
    else if (type == Type.Enemy)
    {
      // move downwards if not targeting
      if (!targetPlayer)
      {
        transform.position += (Vector3)new Vector2(0, -speed * Time.deltaTime);
      }
      // otherwise use direction vector to move
      else
      {
        transform.position += direction * speed * Time.deltaTime;
      }
    }

    // delete projectiles that are out of bounds
    if (((Vector2)transform.position).magnitude > outOfBounds)
    {
      Destroy(gameObject);
    }
  }

  // so other things can destroy this
  public void Destroy()
  {
    Destroy(gameObject);
  }
}
