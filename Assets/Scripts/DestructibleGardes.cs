using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DestructibleGardes : MonoBehaviour
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
            KnifeThrowing[] knifes = transform.GetComponentsInChildren<KnifeThrowing>();
            foreach (KnifeThrowing knife in knifes)
            {
                knife.isActive = true;
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
    }

    void OnDestroy()
    {
        Level.instance.RemoveEnemy();
    }
}
