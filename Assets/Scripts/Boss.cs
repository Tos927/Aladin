using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Lampe[] lampes;
    private bool shoot;

    // Start is called before the first frame update
    void Start()
    {
        lampes = transform.GetComponentsInChildren<Lampe>();
    }

    // Update is called once per frame
    void Update()
    {
        shoot = Input.GetKeyDown(KeyCode.LeftControl);
        if (shoot)
        {
            shoot = false;
            foreach (Lampe lampe in lampes)
            {
                lampe.Shoot();
            }
        }
    }
}
