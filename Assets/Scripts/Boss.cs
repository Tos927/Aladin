using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Lampe[] lampes;
    private bool shoot;
    private bool atkBec;

    public GameObject bcBec;
    private Vector2 bcPos;
    public GameObject bcBody;

    public float speedAtkPic = 6;
    private bool isAttacking = false;
    private bool topReach = false;
    public float speedAtkFly = 4;


    void Start()
    {
        lampes = transform.GetComponentsInChildren<Lampe>();
        bcPos = bcBec.transform.position;
    }
    
    void Update()
    {
        atkBec = Input.GetKey(KeyCode.A);
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
            isAttacking = true;
        }
        
    }

    private void FixedUpdate()
    {
        if (isAttacking)
        {
            Vector2 pos = bcBec.transform.position;
            pos.x -= speedAtkPic * Time.fixedDeltaTime;
            bcBec.transform.position = pos;
            StartCoroutine(CoolDownAtkBec());

        }
    }

    IEnumerator CoolDownAtkBec()
    {
        yield return new WaitForSeconds(1);
        isAttacking = false;
        bcBec.transform.position = bcPos;
    }
}
