using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSin : MonoBehaviour
{
    private float sinCenterY;
    public float amplitude = 2;
    public float frequency = 0.5f;

    public bool inverted;   

    void Start()
    {
        sinCenterY = transform.position.y;
    }
    

    void FixedUpdate()
    {
        Vector2 pos = transform.position;

        float sin = Mathf.Sin(pos.x * frequency) * amplitude;
        if (inverted)
        {
            sin *= -1;
        }
        pos.y = sin + sinCenterY;

        transform.position = pos;
    }
}
