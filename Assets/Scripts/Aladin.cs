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

    public Health health;

    public int lifePoints = 3;
    public Slider ultiCooldown;
    public GameObject deathScreen;
    public SpriteRenderer graphics;

    public GameObject ultime;
    public GameObject ultimeAttack;
    private Vector2 ultimePosStart;
    private bool isUlti = false;
    public float speedUlti = 10;

    private bool isInvincible = false;

    void Start()
    {
        lampes = transform.GetComponentsInChildren<Lampe>();
        foreach (Lampe lampe in lampes)
        {
            lampe.isActive = true;
        }

        ultimePosStart = ultimeAttack.transform.position;
        ultime.SetActive(false);
        ultimeAttack.SetActive(false);
    }
    
    void Update()
    {
        moveUp = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Z);
        moveDown = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
        moveLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q);
        moveRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
        speedUp = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        ulti = Input.GetKeyDown(KeyCode.E) /*|| Input.GetKeyDown(KeyCode.Space)*/;
        shoot = Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0);
        if (shoot)
        {
            shoot = false;
            foreach (Lampe lampe in lampes)
            {
                lampe.Shoot();
            }
        }

        if (ulti)
        {
            isUlti = true;
            ultime.SetActive(true);
            ultimeAttack.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        if (isUlti)
        {
            Vector2 pos1 = ultimeAttack.transform.position;
            pos1.x += speedUlti * Time.fixedDeltaTime;
            ultimeAttack.transform.position = pos1;
            StartCoroutine(CoolDownInUlti());
        }

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

        pos += move; //mettre les valeurs en variable public pour GD ou pas
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
        if (bullet != null && bullet.isEnemy && isInvincible == false)
        {
            TakeDamage();
            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            if (lifePoints <= 0)
            {
                Destroy(gameObject);
                Time.timeScale = 0;
                deathScreen.SetActive(true);
            }
            Destroy(bullet.gameObject);
        }

        Rock rock = collision.GetComponent<Rock>();
        if (rock != null && isInvincible == false)
        {
            TakeDamage();
            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            if (lifePoints <= 0)
            {
                Destroy(gameObject);
                Time.timeScale = 0;
                deathScreen.SetActive(true);
            }
        }

        Lava lava = collision.GetComponent<Lava>();
        if (lava != null && isInvincible == false)
        {
            TakeDamage();
            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            if (lifePoints <= 0)
            {
                Destroy(gameObject);
                Time.timeScale = 0;
                deathScreen.SetActive(true);
            }
        }

        LanceSwing lance = collision.GetComponent<LanceSwing>();
        if (lance != null && isInvincible == false)
        {
            TakeDamage();
            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            if (lifePoints <= 0)
            {
                Destroy(gameObject);
                Time.timeScale = 0;
                deathScreen.SetActive(true);
            }
        }

        Destructible destructible = collision.GetComponent<Destructible>();
        if (destructible != null && isInvincible == false)
        {
            TakeDamage();
            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            if (lifePoints <= 0)
            {
                Destroy(gameObject);
                Time.timeScale = 0;
                deathScreen.SetActive(true);
            }
            Destroy(destructible.gameObject);
        }
    }

    private void TakeDamage()
    {
        health.health--;
        lifePoints--;
    }

    private IEnumerator InvincibilityFlash()
    {
        while (isInvincible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(0.2f);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(0.2f);
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(0.2f);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(2.4f);
            isInvincible = false;
        }
    }

    private IEnumerator CoolDownInUlti()
    {
        yield return new WaitForSeconds(2);
        isUlti = false;
        ultimeAttack.transform.position = ultimePosStart;
        ultimeAttack.SetActive(false);
        ultime.SetActive(false);
    }
}
