using UnityEngine;

public class MovimientoDeJugador1 : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 MovimientoJugador = Vector3.zero;
    [SerializeField] private float VelocidadJugador;
    private float Gravedad = -9.81f;

    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 Movimiento = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(Movimiento * Time.deltaTime * VelocidadJugador);

        if (Movimiento != Vector3.zero)
        {
            gameObject.transform.forward = Movimiento;
        }

        MovimientoJugador.y += Gravedad * Time.deltaTime;//Hace que el jugador no se quede flotando.
        controller.Move(MovimientoJugador * Time.deltaTime);
    }
}