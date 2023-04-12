using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerRandom : MonoBehaviour
{
    public string[] nombreEscenas;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Obtiene un índice aleatorio de la lista de escenas
            int indiceEscena = Random.Range(0, nombreEscenas.Length);

            // Carga la escena correspondiente al índice aleatorio
            SceneManager.LoadScene(nombreEscenas[indiceEscena]);
        }
    }
}
