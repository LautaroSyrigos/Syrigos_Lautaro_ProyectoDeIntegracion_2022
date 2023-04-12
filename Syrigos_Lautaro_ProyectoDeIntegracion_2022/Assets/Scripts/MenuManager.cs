using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void EscenaJuego()
    {
        SceneManager.LoadScene("Transicion Random");
    }

    public void CargarNivel(string Nombre)
    {
        SceneManager.LoadScene(Nombre);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
