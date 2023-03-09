using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class SpawnDeNotas : MonoBehaviour
{
    // Instanciar prefabs
    public GameObject[] prefabs;// Array que almacena los prefabs que quieres instanciar
    public List<GameObject> PosicionesReferencias;// Lista que almacena los GameObjects vacíos que utilizarás como referencia
    private List<Vector3> PosicionesUsadas = new List<Vector3>();// Lista que almacena las posiciones de los GameObjects vacíos utilizados para instanciar los prefabs


    void Start()
    {
        #region Funcion para spawnear las notas musicales.
        foreach (GameObject prefab in prefabs)// Recorre el array de prefabs
        {
            // Selecciona una posición aleatoria del array de referencias vacías que no haya sido utilizada antes
            Vector3 PosicionRandom = Vector3.zero;
            bool PosicionEncontrada = false;
            while (!PosicionEncontrada)
            {
                int randomIndex = Random.Range(0, PosicionesReferencias.Count);
                PosicionRandom = PosicionesReferencias[randomIndex].transform.position;
                if (!PosicionesUsadas.Contains(PosicionRandom))
                {
                    PosicionesUsadas.Add(PosicionRandom);
                    PosicionEncontrada = true;
                }
            }
            Instantiate(prefab, PosicionRandom, Quaternion.identity);// Instancia el prefab en la posición seleccionada
        }
        #endregion


    }

    void Update()
    {
        
    }

    /*TODO
        * 
        * identifique los triggers correctos 
        * una vez que active el pilar empieza el temporizador+si no lo consigue game over y opcion de reiniciar+ganaste te manda al inicio
        * Muestre en la iu lo que hay que hacer
        */
}
