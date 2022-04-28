using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class Aladin : MonoBehaviour
{
    private Lampe[] lampes;
    public float moveSpeed = 5.0f;

    private bool moveUp;
    private bool moveDown;
    private bool moveLeft;
    private bool moveRight;
    private bool speedUp;

    private bool shoot;
    private bool ulti;

    public int lifePoints = 3;
    public Slider ultiCooldown;
    public GameObject deathScreen;

    void Start()
    {
        lampes = transform.GetComponentsInChildren<Lampe>();
        foreach (Lampe lampe in lampes)
        {
            lampe.isActive = true;
        }
    }
    
    void Update()
    {
        moveUp = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Z);
        moveDown = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        moveLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q);
        moveRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        speedUp = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        ulti = Input.GetKey(KeyCode.E) /*|| Input.GetKeyDown(KeyCode.Space)*/;
        shoot = Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0);
        if (shoot)
        {
            shoot = false;
            foreach (Lampe lampe in lampes)
            {
                lampe.Shoot();
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        float moveAmount = moveSpeed * Time.fixedDeltaTime;
        if (speedUp)
        {
            moveAmount *= 3;
        }
        Vector2 move = Vector2.zero;

        if (moveUp)
        {
            move.y += moveAmount;
        }
        if (moveDown)
        {
            move.y -= moveAmount;
        }
        if (moveLeft)
        {
            move.x -= moveAmount;
        }
        if (moveRight)
        {
            move.x += moveAmount;
        }

        float moveMagnitude = Mathf.Sqrt((move.x * move.x) + (move.y * move.y));
        if (moveMagnitude > moveAmount)
        {
            float ratio = moveAmount / moveMagnitude;
            move *= ratio;
        }

        pos += move; //mettre les valeurs en variable public pour GD
        if (pos.x <=0.6f)
        {
            pos.x = 0.6f;
        }

        if (pos.x >= 17f)
        {
            pos.x = 17;
        }

        if (pos.y <=1)
        {
            pos.y = 1;
        }

        if (pos.y >=9)
        {
            pos.y = 9f;
        }

        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.GetComponent<Bullet>();
        if (bullet != null && bullet.isEnemy)
        {
            lifePoints--;
            if (lifePoints <= 0)
            {
                Destroy(gameObject);
                Time.timeScale = 0;
                deathScreen.SetActive(true);
            }
            Destroy(bullet.gameObject);
        }

        Rock rock = collision.GetComponent<Rock>();
        if (rock != null)
        {
            lifePoints--;
            if (lifePoints <= 0)
            {
                Destroy(gameObject);
                Time.timeScale = 0;
                deathScreen.SetActive(true);
            }
        }

        Lava lava = collision.GetComponent<Lava>();
        if (lava != null)
        {
            lifePoints--;
            if (lifePoints <= 0)
            {
                Destroy(gameObject);
                Time.timeScale = 0;
                deathScreen.SetActive(true);
            }
        }

        LanceSwing lance = collision.GetComponent<LanceSwing>();
        if (lance != null)
        {
            lifePoints--;
            if (lifePoints <= 0)
            {
                Destroy(gameObject);
                Time.timeScale = 0;
                deathScreen.SetActive(true);
            }
        }

        Destructible destructible = collision.GetComponent<Destructible>();
        if (destructible != null)
        {
            lifePoints--;
            if (lifePoints <= 0)
            {
                Destroy(gameObject);
                Time.timeScale = 0;
                deathScreen.SetActive(true);
            }
            Destroy(destructible.gameObject);
        }
    }
}
