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

  public ProjectileController()
  {

  }
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if(type == Type.Player){
      transform.position += (Vector3)new Vector2(0, speed * Time.deltaTime);
    }
    if(((Vector2)transform.position).magnitude > outOfBounds){
      Destroy(gameObject);
    }
  }

  void OnCollisionEnter2D(Collision2D collision){
    
  }
}
