using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class temp_06 : MonoBehaviour
{
    public TMP_Text Vida;
    public int health = 100;

    private void Update()
    {
        Vida.text = "Vida: " + health.ToString();

        if(health < 1)
        {
            Vida.text = "Muerto";
        }
    }
}
