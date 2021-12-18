using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Text healthText;
    [SerializeField] private bool isAlive = true;
    public ButtonManager buttonManager;
    public Text damageText;
    public int health = 0;
    public int healthLost;
    public int finalHealth;

    void Start()
    {
        damageText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = health.ToString();
        damageText.text = healthLost.ToString();

        if (health == 0)
        {
            isAlive = false;
        }
    }
}
