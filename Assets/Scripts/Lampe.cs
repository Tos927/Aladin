using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lampe : MonoBehaviour
{
    public Bullet bullet;
    private Vector2 direction;

    public bool autoShoot = false;
    public float shootIntervalSeconds = 0.5f;
    public float shootDelaySeconds = 2.0f;
    private float shootTimer = 0f;
    float delayTimer = 0f;

    public AudioSource woosh;
    public bool isEnemy;
    public bool isActive = false;

    void Update()
    {
        if (!isActive)
        {
            return;
        }
        direction = (transform.localRotation * Vector2.right).normalized;

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
        if (!isEnemy)
        {
            woosh.Play();
        }

        GameObject gameObject = Instantiate(bullet.gameObject, transform.position, Quaternion.identity);
        Bullet bulletDir = gameObject.GetComponent<Bullet>();
        bulletDir.direction = direction;
    }
}
