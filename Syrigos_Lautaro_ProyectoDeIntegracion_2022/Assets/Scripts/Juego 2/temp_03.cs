using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp_03 : MonoBehaviour
{
    List<GameObject>Notas = new List<GameObject>();



    /*
    public class PosicionarSe�alador : MonoBehaviour
    {
        public string etiquetaObjetos; // Etiqueta com�n en los objetos que contienen los Empty
        public GameObject objetoSe�alador; // Objeto se�alador que se posicionar� sobre los otros objetos

        private List<Vector3> posicionesEmpty = new List<Vector3>();

        void Start()
        {
            // Obtener una lista de los objetos que contienen los Empty
            GameObject[] objetosConEmpty = GameObject.FindGameObjectsWithTag(etiquetaObjetos);

            // Para cada objeto que contiene un Empty, obtener la posici�n del Empty y almacenarla en una lista
            foreach (GameObject objetoConEmpty in objetosConEmpty)
            {
                Transform empty = objetoConEmpty.transform.Find("Empty"); // Suponiendo que el Empty se llama "Empty"
                if (empty != null)
                {
                    Vector3 posicionEmpty = empty.position;
                    posicionesEmpty.Add(posicionEmpty);
                }
            }

            // Encontrar la posici�n promedio de los Empty
            Vector3 posicionPromedio = Vector3.zero;
            foreach (Vector3 posicionEmpty in posicionesEmpty)
            {
                posicionPromedio += posicionEmpty;
            }
            posicionPromedio /= posicionesEmpty.Count;

            // Colocar el objeto se�alador en la posici�n promedio de los Empty
            objetoSe�alador.transform.position = posicionPromedio;
        }
    }
    */
}
