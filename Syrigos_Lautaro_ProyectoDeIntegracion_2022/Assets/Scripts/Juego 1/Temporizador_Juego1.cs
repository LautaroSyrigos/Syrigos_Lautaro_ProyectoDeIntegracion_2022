using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Temporizador_Juego1 : MonoBehaviour
{
    public float tiempoRestante = 60.0f;
    public TextMeshProUGUI textoTemporizador;

    void Start()
    {
        ActualizarTextoTemporizador();
    }

    void Update()
    {
        tiempoRestante -= Time.deltaTime;
        ActualizarTextoTemporizador();

        if (tiempoRestante <= 0)
        {
            tiempoRestante = 0;
            // realiza cualquier acción que desees cuando el temporizador llega a cero
            Debug.Log("Perdiste");
        }
    }

    void ActualizarTextoTemporizador()
    {
        int segundos = Mathf.FloorToInt(tiempoRestante % 60);
        int minutos = Mathf.FloorToInt(tiempoRestante / 60);

        textoTemporizador.text = string.Format("{0:0}:{1:00}", minutos, segundos);
    }
}
