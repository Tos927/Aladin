using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Destructible : MonoBehaviour
{
    private bool canBeDestroy = false;

    public int pointToWin = 100;

    void Start()
    {
        Level.instance.AddEnemy();
    }

    void Update()
    {
        if (transform.position.x < 17.0f && !canBeDestroy)
        {
            canBeDestroy = true;
            KnifeThrowing[] lampes = transform.GetComponentsInChildren<KnifeThrowing>();
            foreach (KnifeThrowing lampe in lampes)
            {
                lampe.isActive = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!canBeDestroy)
        {
            return;
        }
        Bullet bullet = collision.GetComponent<Bullet>();
        if (bullet != null && !bullet.isEnemy)
        {
            Level.instance.AddScore(pointToWin);
            Destroy(gameObject);
            Destroy(bullet.gameObject);
        }

        if (collision.tag == "Ulti")
        {
            Debug.Log("touché");
            Level.instance.AddScore(pointToWin);
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        Level.instance.RemoveEnemy();
    }
}
