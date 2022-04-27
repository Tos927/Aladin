using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        Vector2 pos = transform.position;
        while (transform.position.y < 9)
        {
            pos.y += Time.deltaTime;
            
        }

        //pos.y -= Time.deltaTime;

        transform.position = pos;
    }
}
