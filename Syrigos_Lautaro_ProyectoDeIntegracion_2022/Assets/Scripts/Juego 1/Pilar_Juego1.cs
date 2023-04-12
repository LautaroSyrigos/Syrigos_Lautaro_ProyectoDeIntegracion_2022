using UnityEngine;
using UnityEngine.UI;

public class Pilar_Juego1 : MonoBehaviour
{
    public GameObject[] Prefabs;
    private bool SePuedeGenerar = false;
    public Image ImagenParaUI;

    void Update()
    {
        //Arreglar
        #region Control para invocar las notas musicales(prefabs).
        if (Input.GetKeyDown(KeyCode.I) && !SePuedeGenerar)
        {
            for (int i = 0; i < Prefabs.Length; i++)
            {
                Vector3 randomSpawnPosition = new Vector3(Random.Range(-8, 10), 5, Random.Range(-8, 10));
                Instantiate(Prefabs[i], randomSpawnPosition, Quaternion.identity);
            }
            SePuedeGenerar = true;
        }
        #endregion
    }

    #region Deteccion del jugador para interactuar con el pilar.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SePuedeGenerar = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SePuedeGenerar = false;
        }
    }
#endregion

    /*
    #region UI para la interaccion con el pilar 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            ImagenParaUI.gameObject.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            ImagenParaUI.gameObject.SetActive(false);
        }
    }
    #endregion
    */

}


/*
 * public GameObject[] myObjects;
    private bool spawned = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !spawned)
        {
            for (int i = 0; i < myObjects.Length; i++)
            {
                Vector3 randomSpawnPosition = new Vector3(Random.Range(-8, 10), 5, Random.Range(-8, 10));
                Instantiate(myObjects[i], randomSpawnPosition, Quaternion.identity);
            }
            spawned = true;
        }
    }
 */
