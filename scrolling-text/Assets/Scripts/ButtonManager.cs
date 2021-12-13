using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject hurtButton;
    public TextManager textManager;
    public bool healthDecreasing = false;

    void Start()
    {
        hurtButton.SetActive(true);
    }

    void Update()
    {
        if (healthDecreasing || textManager.health == 0)
        {
            hurtButton.SetActive(false);
        }
        else
        {
            hurtButton.SetActive(true);
        }
    }

    public void HurtButtonPressed()
    {
        int finalHealth = textManager.health - textManager.healthLost;

        
        textManager.damageText.gameObject.SetActive(true);

        if (finalHealth < 0)
        {
            finalHealth = 0;
        }

        StartCoroutine(HurtOverTime(finalHealth));
    }

    IEnumerator HurtOverTime(int goalHealth)
    {
        while (textManager.health > goalHealth)
        {
            healthDecreasing = true;
            textManager.health--;
            yield return new WaitForSeconds(0.1f);
        }
        healthDecreasing = false;
    }
}
