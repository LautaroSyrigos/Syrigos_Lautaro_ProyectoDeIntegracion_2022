using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class temp_03 : MonoBehaviour
{
    List<GameObject>Notas = new List<GameObject>();



    /*
    public class PosicionarSeñalador : MonoBehaviour
    {
        public string etiquetaObjetos; // Etiqueta común en los objetos que contienen los Empty
        public GameObject objetoSeñalador; // Objeto señalador que se posicionará sobre los otros objetos

        private List<Vector3> posicionesEmpty = new List<Vector3>();

        void Start()
        {
            // Obtener una lista de los objetos que contienen los Empty
            GameObject[] objetosConEmpty = GameObject.FindGameObjectsWithTag(etiquetaObjetos);

            // Para cada objeto que contiene un Empty, obtener la posición del Empty y almacenarla en una lista
            foreach (GameObject objetoConEmpty in objetosConEmpty)
            {
                Transform empty = objetoConEmpty.transform.Find("Empty"); // Suponiendo que el Empty se llama "Empty"
                if (empty != null)
                {
                    Vector3 posicionEmpty = empty.position;
                    posicionesEmpty.Add(posicionEmpty);
                }
            }

            // Encontrar la posición promedio de los Empty
            Vector3 posicionPromedio = Vector3.zero;
            foreach (Vector3 posicionEmpty in posicionesEmpty)
            {
                posicionPromedio += posicionEmpty;
            }
            posicionPromedio /= posicionesEmpty.Count;

            // Colocar el objeto señalador en la posición promedio de los Empty
            objetoSeñalador.transform.position = posicionPromedio;
        }
    }
    */
}
