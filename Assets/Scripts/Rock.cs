using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject cailloux;

    private void Start()
    {
        rb.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (cailloux.transform.position >= 17.0f)
        {
            rb.BodyType.Set
        }
    }
}
