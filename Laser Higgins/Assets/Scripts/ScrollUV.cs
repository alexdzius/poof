using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUV : MonoBehaviour
{
    Rigidbody2D go;
    void Start()
    {
       go = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 position = go.transform.position;
        go.velocity = new Vector3(0, -1, 0);
        if(position.y < -10)
        {
            go.transform.position = new Vector3(0, 20, 0);
        }
    }
}
