using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public float speed = 0.1f;
    private bool topReach = false;

    void FixedUpdate()
    {
        Vector2 pos = transform.position;

        if (pos.y < 9 && !topReach)
        {
            pos.y += speed * Time.fixedDeltaTime;
        }
        
        if (pos.y >= 9 || topReach)
        {
            pos.y -= speed * Time.fixedDeltaTime;
            topReach = true;
        }

        if (pos.y <= -5)
        {
            Destroy(gameObject);
        }

        transform.position = pos;
        

    }
}
