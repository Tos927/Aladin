using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Lampe[] lampes;
    private bool shoot;
    private bool atkBec;

    public GameObject bcBec;
    public GameObject bcBody;

    public float speedAtkPic = 2;
    private bool isAttacking = false;
    private bool topReach = false;
    public float speedAtkFly = 4;


    void Start()
    {
        lampes = transform.GetComponentsInChildren<Lampe>();
    }
    
    void Update()
    {
        atkBec = Input.GetKeyDown(KeyCode.A);
        shoot = Input.GetKeyDown(KeyCode.LeftControl);
        if (shoot)
        {
            shoot = false;
            foreach (Lampe lampe in lampes)
            {
                lampe.Shoot();
            }
        }

        if (atkBec)
        {
            Debug.Log("PicPic");
            isAttacking = true;
            AtkPic(isAttacking);
            isAttacking = false;
        }
    }

    /*private void FixedUpdate()
    {
        Vector2 pos = bcBec.transform.position;
        pos.x -= speedAtkPic * Time.deltaTime;
        
        if (pos.x <= -5 && !topReach)
        {
            pos.x += speedAtkPic * Time.deltaTime;
        }

        if (pos.x >= 0 || topReach)
        {
            topReach = true;
            pos.x = 0;
        }

        bcBec.transform.position = pos;
    }*/

    private void AtkPic(bool attacking)
    {
        Vector2 pos = bcBec.transform.position;

        while (attacking)
        {
            if (!topReach)
            {
                pos.x -= speedAtkPic * Time.deltaTime;
            }

            if (pos.x <= -5)
            {
                pos.x += speedAtkPic * Time.fixedDeltaTime;
                topReach = true;
            }

            if (pos.x >= 0)
            {
                pos.x = 0;
            }

            bcBec.transform.position = pos;
            attacking = false;
        }
    }
}
