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
  public float speed = 5f;
  public float outOfBounds = 20f;
  public bool targetPlayer = false;
  public Vector3 playerPos;
  private Vector3 direction;

  public ProjectileController()
  {

  }
  // Start is called before the first frame update
  void Start()
  {
    direction = (Vector3.MoveTowards(transform.position, playerPos, 1) - transform.position).normalized;
  }

  // Update is called once per frame
  void Update()
  {
    if (type == Type.Player)
    {
      transform.position += (Vector3)new Vector2(0, speed * Time.deltaTime);
    }
    else if (type == Type.Enemy)
    {
      if (!targetPlayer)
      {
        transform.position += (Vector3)new Vector2(0, -speed * Time.deltaTime);
      }
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
