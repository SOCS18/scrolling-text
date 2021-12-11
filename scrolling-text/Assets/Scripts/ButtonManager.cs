using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public TextManager textManager;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HurtButtonPressed()
    {
        Debug.Log("Pressed Hurt Button!");
        if (textManager.health == 0)
        {
            textManager.health = 0;
        }
        else
        {
            textManager.health--;
        }
    }
}
