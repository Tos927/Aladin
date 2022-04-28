using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject cailloux;

    private void Start()
    {
        rb = cailloux.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (cailloux.transform.position.x >= 10.0f)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
        }
        else
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
