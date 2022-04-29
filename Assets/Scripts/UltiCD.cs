using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltiCD : MonoBehaviour
{
    public Image ultiImage;
    public float cooldown;
    private bool isCooldown = false;

    void Start()
    {
        ultiImage.fillAmount = 0;
    }

    void Update()
    {
        Ulti();
    }

    void Ulti()
    {
        if (Input.GetKey(KeyCode.Space) && isCooldown == false)
        {
            isCooldown = true;
            ultiImage.fillAmount = 1;
        }

        if (isCooldown)
        {
            ultiImage.fillAmount -= 1 / cooldown * Time.deltaTime;

            if (ultiImage.fillAmount <= 0)
            {
                ultiImage.fillAmount = 0;
                isCooldown = false;
            }
        }
    }
}
