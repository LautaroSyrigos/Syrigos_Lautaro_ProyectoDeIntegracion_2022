using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class temp_05 : MonoBehaviour
{
    public Image circulo;
    public float escalaInicial = 1f;
    public float escalaMaxima = 2f;
    public float velocidadCrecimiento = 1f;
    public float velocidadDecrecimiento = 1f;

    private bool estaPulsando = false;
    private float escalaActual;

    private void Start()
    {
        escalaActual = escalaInicial;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            estaPulsando = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            estaPulsando = false;
        }

        if (estaPulsando)
        {
            escalaActual += velocidadCrecimiento * Time.deltaTime;
            escalaActual = Mathf.Clamp(escalaActual, escalaInicial, escalaMaxima);
        }
        else
        {
            escalaActual -= velocidadDecrecimiento * Time.deltaTime;
            escalaActual = Mathf.Clamp(escalaActual, escalaInicial, escalaMaxima);
        }

        circulo.transform.localScale = new Vector3(escalaActual, escalaActual, 1f);
    }
}
