using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
  public float distance;

  public float speed = 3f;

  public enum Type
  {
    Chaser,
    Pacer,
    Kamikaze
  }
  // Times fired per second
  public float fireRate = 0.7f;
  private float timeSinceLastFire = 0f;


  float timeSinceTurn;
  float timeToNextTurn;
  private bool positive = true;
  private bool vertical = true;
  private float top;
  private float bottom;

  public Type name;

  public GameObject enemyBullet;

  [SerializeField] public GameObject player;
  // Start is called before the first frame update
  void Start()
  {
    player = GameManager.player;
    Type[] types = (Type[])System.Enum.GetValues(typeof(Type));
    name = types[(int)Random.Range(0, types.Length)];
    print(name);
    timeToNextTurn = Random.Range(0.5f, 3f);
    top = Random.Range(2, 4);
    bottom = 4;
    // make sure bottom y bound is lower
    while (bottom > top)
    {
      bottom = Random.Range(0, 4);
    }
  }

  // Update is called once per frame
  void Update()
  {
    bool fire = false;
    timeSinceLastFire += Time.deltaTime;
    if (timeSinceLastFire > 1 / fireRate)
    {
      // makes sure it doesn't fire more than once quickly
      timeSinceLastFire %= 1 / fireRate;
      fire = true;
    }
    distance = Vector3.Distance(transform.position, player.transform.position);
    switch (name)
    {
      case Type.Chaser:
        // randomized movement
        if (distance < 4 && player.transform.position.y > 0)
        {
          transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 1f * speed * Time.deltaTime);
        }
        else
        {
          transform.position = Vector3.MoveTowards(transform.position, player.transform.position + new Vector3(Random.Range(-1f, 1f), 4.5f, 0), 1f * speed * Time.deltaTime);
        }
        if (fire) Fire();
        break;
      case Type.Pacer:
        // horizontal movement
        // if within bounds
        if (Mathf.Abs(transform.position.x) > 2.5f)
        {
          positive = !positive;
        }
        if (transform.position.y > top) vertical = false;
        if (transform.position.y < bottom) vertical = true;
        transform.position += new Vector3(positive ? 1 : -1, 0, 0) * speed * Time.deltaTime;
        // vertical movement
        transform.position += new Vector3(0, vertical ? 1 : -1, 0) * speed * Time.deltaTime;
        if (fire) Fire(true);
        break;
      case Type.Kamikaze:
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 1.5f * speed * Time.deltaTime);
        break;
    }
    timeSinceTurn += Time.deltaTime;
    if (timeSinceTurn > timeToNextTurn)
    {
      positive = !positive;
      timeSinceTurn = 0;
      timeToNextTurn = Random.Range(0.5f, 3f);
    }
    // randomize shooting  
  }

  void OnCollisionEnter2D(Collision2D collision)
  {
    print("hit");
    ProjectileController controller = collision.gameObject.GetComponent<ProjectileController>();
    if (controller != null)
    {
      if (controller.type == ProjectileController.Type.Player)
      {
        // if it hits an enemy projectile, then decrease lives and then destroy the bullet
        GameManager.TotalScore++;
        controller.Destroy();
        Destroy(gameObject);
      }
    }
  }

  // set parameter true to send a homing missile
  void Fire(bool target = false)
  {
    GameObject bullet = Instantiate(enemyBullet);
    bullet.GetComponent<ProjectileController>().type = ProjectileController.Type.Enemy;
    // teleport bullet to player
    bullet.transform.position = transform.position;
    // target player if set
    bullet.GetComponent<ProjectileController>().targetPlayer = target;
    bullet.GetComponent<ProjectileController>().playerPos = player.transform.position;
  }
}
