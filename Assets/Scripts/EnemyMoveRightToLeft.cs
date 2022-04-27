using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveRightToLeft : MonoBehaviour
{
    public float moveSpeed = 5;

    void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos.x -= moveSpeed * Time.deltaTime;

        if (pos.x < -2)
        {
            Destroy(gameObject);
        }

        transform.position = pos;
    }
}
