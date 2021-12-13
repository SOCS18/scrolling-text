using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        StartCoroutine(FadeText(1f, textManager.damageText));

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

    IEnumerator FadeText(float time, Text damage)
    {
        damage.color = new Color(damage.color.r, damage.color.g, damage.color.b, 1);
        while (damage.color.a > 0.0f)
        {
            damage.color = new Color(damage.color.r, damage.color.g, damage.color.b, damage.color.a - (Time.deltaTime / time));
            yield return null;
        }
    }
}
