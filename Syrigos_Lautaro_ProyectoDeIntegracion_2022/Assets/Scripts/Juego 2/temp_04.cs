using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class temp_04 : MonoBehaviour
{
    public List<Button> botones;
    private List<Transform> botonesTransforms;
    public AudioClip sonidoCorrecto;
    private AudioSource audioSource;

    private void Start()
    {
        botonesTransforms = new List<Transform>();

        // Generar un índice al azar para determinar el botón correcto
        int indiceCorrecto = Random.Range(0, botones.Count);

        // Guardar las referencias de transform de los botones
        foreach (Button boton in botones)
        {
            botonesTransforms.Add(boton.transform);
        }

        // Mezclar aleatoriamente los botones en la lista de transform
        MezclarBotones();

        // Asignar la función de manejo de clics a todos los botones
        for (int i = 0; i < botones.Count; i++)
        {
            int indice = i; // Necesitamos almacenar el valor actual de 'i' para usarlo en el listener
            botones[indice].onClick.AddListener(() => BotonPresionado(indice, indiceCorrecto));
        }

        audioSource = GetComponent<AudioSource>();
    }

    private void MezclarBotones()
    {
        int n = botonesTransforms.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            Transform botonTemporal = botonesTransforms[k];
            botonesTransforms[k] = botonesTransforms[n];
            botonesTransforms[n] = botonTemporal;
        }

        // Actualizar las posiciones de los botones en la interfaz de usuario (UI)
        for (int i = 0; i < botonesTransforms.Count; i++)
        {
            botonesTransforms[i].SetSiblingIndex(i);
        }
    }

    private void BotonPresionado(int indice, int indiceCorrecto)
    {
        if (indice == indiceCorrecto)
        {
            Debug.Log("¡El botón correcto ha sido presionado!");
            audioSource.PlayOneShot(sonidoCorrecto);
        }
        else
        {
            Debug.Log("El botón incorrecto ha sido presionado.");
        }
    }

    /*
    public List<Button> botones;

    private void Start()
    {
        // Generar un índice al azar para determinar el botón correcto
        int indiceCorrecto = Random.Range(0, botones.Count);

        MezclarBotones();

        // Asignar la función de manejo de clics a todos los botones
        for (int i = 0; i < botones.Count; i++)
        {
            int indice = i; // Necesitamos almacenar el valor actual de 'i' para usarlo en el listener
            botones[i].onClick.AddListener(() => BotonPresionado(indice, indiceCorrecto));
        }
    }

    private void MezclarBotones()
    {
        int n = botones.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            Button botonTemporal = botones[k];
            botones[k] = botones[n];
            botones[n] = botonTemporal;
        }

        // Actualizar las posiciones de los botones en la interfaz de usuario (UI)
        for (int i = 0; i < botones.Count; i++)
        {
            botones[i].transform.SetSiblingIndex(i);
        }
    }

    private void BotonPresionado(int indice, int indiceCorrecto)
    {
        if (indice == indiceCorrecto)
        {
            Debug.Log("¡El botón correcto ha sido presionado!");
        }
        else
        {
            Debug.Log("El botón incorrecto ha sido presionado.");
        }
    }

    */
}
