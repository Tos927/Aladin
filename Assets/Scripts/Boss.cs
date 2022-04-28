using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Lampe[] lampes;
    private bool shoot;
    private bool atkBec;
    private bool atkFly;

    public GameObject boss;
    public BoxCollider2D bcBoss;
    private SpriteRenderer spBoss;
    public GameObject bcBec;
    public SpriteRenderer spBec;
    private Vector2 bcBecPos;
    public GameObject bcBody;
    public SpriteRenderer spBody;
    private Vector2 bcBodyPos;

    public float speedAtkPic = 6;
    private bool isAttacking1 = false;
    private bool isAttacking2 = false;
    private bool isAttacking3 = false;
    private bool topReach = false;
    public float speedAtkFly = 4;

    private int randomizer;
    public int pointToWin = 10000;

    private bool canBeDestroy = true;

    public int health = 30;
    public GameObject victoryScreen;

    void Start()
    {
        lampes = transform.GetComponentsInChildren<Lampe>();
        bcBecPos = bcBec.transform.position;
        bcBodyPos = bcBody.transform.position;
        bcBoss = boss.GetComponent<BoxCollider2D>();
        spBoss = boss.GetComponentInChildren<SpriteRenderer>();
        spBody.enabled = false;
        spBec.enabled = false;
        StartCoroutine(CoolDownRandomizer());
    }

    void Update()
    {
        //atkBec = Input.GetKey(KeyCode.A);
        //atkFly = Input.GetKey(KeyCode.M);
        //shoot = Input.GetKeyDown(KeyCode.LeftControl);

        if (randomizer == 0)
        {
            shoot = false;
            foreach (Lampe lampe in lampes)
            {
                lampe.Shoot();
            }
        }
        else if (randomizer == 1)
        {
            isAttacking1 = true;
        }
        else if (randomizer == 2)
        {
            isAttacking2 = true;
        }

    }

    private void FixedUpdate()
    {
        if (isAttacking1)
        {
            spBec.enabled = true;
            Vector2 pos = bcBec.transform.position;
            pos.x -= speedAtkPic * Time.fixedDeltaTime;
            bcBec.transform.position = pos;
            StartCoroutine(CoolDownAtkBec());
            spBody.enabled = false;
        }

        if (isAttacking2)
        {
            boss.GetComponent<BoxCollider2D>().enabled=false;
            spBoss.enabled = false;
            bcBec.SetActive(false);
            spBody.enabled = true;
            Vector2 pos = bcBody.transform.position;
            pos.x -= speedAtkFly * Time.fixedDeltaTime;
            bcBody.transform.position = pos;
            StartCoroutine(CoolDownAtkBody());
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit");
        if (collision.tag == "BulletPlayer")
        {
            health--;
            if (health <= 0)
            {
                Level.instance.AddScore(pointToWin);
                Destroy(gameObject);
                victoryScreen.SetActive(true);
            }
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "Ulti")
        {
            health--;
            if (health <= 0)
            {
                Level.instance.AddScore(pointToWin);
                Destroy(gameObject);
                victoryScreen.SetActive(true);
            }
        }
    }
    /*void OnTriggerEnter2D(Collider2D collision)
    {
        if (!canBeDestroy)
        {
            return;
        }
        Bullet bullet = collision.GetComponent<Bullet>();
        if (bullet != null && !bullet.isEnemy)
        {
            health--;
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
    }*/

    IEnumerator CoolDownAtkBec()
    {
        yield return new WaitForSeconds(1);
        isAttacking1 = false;
        bcBec.transform.position = bcBecPos;
        spBec.enabled = false;
    }

    IEnumerator CoolDownAtkBody()
    {
        yield return new WaitForSeconds(2);
        isAttacking2 = false;
        bcBody.transform.position = bcBodyPos;
        bcBec.SetActive(true);
        boss.GetComponent<BoxCollider2D>().enabled = true;
        spBoss.enabled = true;
        spBody.enabled = false;
    }

    IEnumerator CoolDownRandomizer()
    {
        randomizer = -1;
        while (true)
        {
            yield return null;
            randomizer = -1;
            yield return new WaitForSeconds(5);
            randomizer = Random.Range(0, 3);
        }
    }
}
