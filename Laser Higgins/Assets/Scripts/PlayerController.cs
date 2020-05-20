using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public float speed = 5f;
  // Times fired per second
  public float fireRate = 4f;
  public float timeSinceLastFire = 0f;
  // Start is called before the first frame update
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {
    // movement stuff
    float yMovement = Input.GetAxisRaw("Vertical");
    float xMovement = Input.GetAxisRaw("Horizontal");
    Vector2 move = new Vector2(xMovement, yMovement).normalized * Time.deltaTime * speed;
    transform.position += (Vector3)move;

    // shoot
    timeSinceLastFire += Time.deltaTime;
    if (Input.GetButtonDown("Fire1"))
    {
      if (timeSinceLastFire > 1 / fireRate)
      {
        timeSinceLastFire -= 1 / fireRate;
        // makes sure it doesn't fire more than once quickly
        timeSinceLastFire = Mathf.Max(timeSinceLastFire, 1 / fireRate);
        Fire();
      }
    }
  }

  void OnCollisionEnter2D(Collision2D collision)
  {

  }
  // fire a plasma something
  void Fire()
  {
    ProjectileController bullet = new ProjectileController();
  }
}
