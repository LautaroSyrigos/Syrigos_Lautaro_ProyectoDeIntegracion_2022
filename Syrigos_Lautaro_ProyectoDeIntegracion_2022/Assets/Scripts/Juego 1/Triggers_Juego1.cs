using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Triggers_Juego1 : MonoBehaviour
{
    public GameObject objetoCorrecto;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == objetoCorrecto)
        {
            Debug.Log("Objeto Correcto");
        }
        else
        {
            Debug.Log("Objeto Incorrecto");
        }
    }

    //bool EsCorrecto;
    //bool Agarrarse;
    ////public GameObject CentroDelObjeto;
    //public GameObject Notas;
    //public GameObject[] OtrasNotas;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject == Notas)
    //    {
    //        Debug.Log("Nota Correcta");
    //    }
    //    else
    //    {

    //    }
    //}
}