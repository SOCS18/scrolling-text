using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public TextManager textManager;

    public void HurtButtonPressed()
    {
        Debug.Log("Pressed Hurt Button!");
        //textManager.health--;
        int finalHealth = textManager.health - textManager.healthLost;

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
            textManager.health--;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
