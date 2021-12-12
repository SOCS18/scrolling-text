using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    [SerializeField] private Text healthText;
    public int health = 0;
    public int healthLost;

    // Update is called once per frame
    void Update()
    {
        healthText.text = health.ToString();
    }
}
