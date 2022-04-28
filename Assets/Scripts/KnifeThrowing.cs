using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeThrowing : MonoBehaviour
{
    public Bullet bullet;
    private Vector2 direction;
    public GameObject player;

    public bool autoShoot = false;
    public float shootIntervalSeconds = 0.5f;
    public float shootDelaySeconds = 2.0f;
    private float shootTimer = 0f;
    float delayTimer = 0f;

    public bool isActive = false;

    void Update()
    {
        if (!isActive)
        {
            return;
        }
        direction = (player.transform.position - transform.position).normalized;

        if (autoShoot)
        {
            if (delayTimer >= shootDelaySeconds)
            {
                if (shootTimer >= shootIntervalSeconds)
                {
                    Shoot();
                    shootTimer = 0;
                }
                else
                {
                    shootTimer += Time.deltaTime;
                }
            }
            else
            {
                delayTimer += Time.deltaTime;
            }
        }
    }

    public void Shoot()
    {
        GameObject gameObject = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
        Bullet bulletDir = gameObject.GetComponent<Bullet>();
        bulletDir.direction = direction;
    }
}