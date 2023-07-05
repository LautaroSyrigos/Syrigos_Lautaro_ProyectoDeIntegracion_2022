using UnityEngine;

public class MovimientoDeJugador1 : MonoBehaviour
{
    [Header("Variables del jugador")]

    private CharacterController controller;
    private Vector3 MovimientoJugador = Vector3.zero;
    [SerializeField] private float VelocidadJugador;
    private float Gravedad = -9.81f;
    private Animator animator;

    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        animator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 Movimiento = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(Movimiento * Time.deltaTime * VelocidadJugador);

        if (Movimiento != Vector3.zero)
        {
            gameObject.transform.forward = Movimiento;
            //animator.SetBool("IsMoving", true); // Establece el parámetro de la animación "IsMoving" en verdadero
            animator.SetFloat("Blend", 0.25f);
        }
        else
        {
            //animator.SetBool("IsMoving", false); // Establece el parámetro de la animación "IsMoving" en falso
            animator.SetFloat("Blend", 0);
        }

        if(Input.GetKeyDown(KeyCode.P)) 
        {
            animator.SetFloat("Blend", 0.5f);
        }

        MovimientoJugador.y += Gravedad * Time.deltaTime;//Hace que el jugador no se quede flotando.
        controller.Move(MovimientoJugador * Time.deltaTime);
    }
}