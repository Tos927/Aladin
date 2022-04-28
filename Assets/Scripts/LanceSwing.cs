using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanceSwing : MonoBehaviour
{
    private BoxCollider2D bd;
    public float speed;
    private Vector2 startPos;
    private bool check = true;
    private float coolDown = 1f;

    void Start()
    {
        bd = transform.GetComponent<BoxCollider2D>();
        startPos = transform.position;
    }
    
    void Update()
    {
        Vector2 pos = transform.position;

        pos.y -= speed * Time.deltaTime;

        if (pos.y < (startPos.y - 1.6))
        {
            if (check)
            {
                pos.y = startPos.y;
                StartCoroutine(Cooldown(check, coolDown));
            }
        }

        transform.position = pos;
    }

    IEnumerator Cooldown(bool action, float coolDown)
    {
        yield return new WaitForSeconds(coolDown);
        action = true;
    }
}
