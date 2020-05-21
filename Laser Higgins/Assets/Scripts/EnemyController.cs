using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float distance;
    [SerializeField] public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // randomized movement
        distance = Vector3.Distance(transform.position, player.transform.position);
        print("Distance to other: " + distance);
        if (transform.position.y >= 3 || player.transform.position.y > 2.5f)
        {
            if (distance > 2)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, .01f);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position + new Vector3(2, 2, 0), .01f);
            }
        }

        // randomize shooting  
    }
}
