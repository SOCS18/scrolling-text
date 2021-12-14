using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    private bool forLoopDone = false;
    public GameObject hurtButton;
    public TextManager textManager;
    public bool healthDecreasing = false;
    public Vector3 damageTextOriginLocation;
    private int numButtons = 4;

    void Start()
    {
        hurtButton.SetActive(true);
        damageTextOriginLocation = textManager.damageText.transform.position;
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

        if (healthDecreasing)
        {
            if (!forLoopDone)
            {
                for (int i = 0; i < numButtons; i++)
                {
                    Debug.Log("Generate button " + (i + 1));
                }
                forLoopDone = true;
            }
        }
    }

    public void HurtButtonPressed()
    {
        textManager.finalHealth = textManager.health - textManager.healthLost;

        textManager.damageText.gameObject.SetActive(true);

        if (textManager.finalHealth < 0)
        {
            textManager.finalHealth = 0;
        }

        if (textManager.finalHealth == 0)
        {
            Debug.Log("FATAL HIT");
            textManager.fatalText.gameObject.SetActive(true);
        }
        else
        {
            textManager.fatalText.gameObject.SetActive(false);
        }

        StartCoroutine(HurtOverTime(textManager.finalHealth));
        StartCoroutine(FadeText(1.25f, textManager.damageText));
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

    IEnumerator FadeText(float fadeTime, Text damage)
    {
        damage.color = new Color(damage.color.r, damage.color.g, damage.color.b, 1);
        while (damage.color.a > 0.0f)
        {
            damage.color = new Color(damage.color.r, damage.color.g, damage.color.b, damage.color.a - (Time.deltaTime / fadeTime));

            yield return null;
        }
    }
}
