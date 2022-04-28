using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lances : MonoBehaviour
{
    public float speed = 0.1f;
    private bool topReach = false;

    void FixedUpdate()
    {
        Vector2 pos = transform.position;

        if (pos.y < 2.5 && !topReach)
        {
            pos.y += speed * Time.fixedDeltaTime;
        }

        if (pos.y >= 2.5 || topReach)
        {
            pos.y -= speed * Time.deltaTime;
            topReach = true;
        }

        if (pos.y <= -4)
        {
            Destroy(gameObject);
        }

        transform.position = pos;


    }
}
