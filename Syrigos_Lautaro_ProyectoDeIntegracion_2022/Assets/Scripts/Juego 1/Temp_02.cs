using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp_02 : MonoBehaviour
{
    public GameObject emptyObject;
    private Vector3 posicionOriginal;
    public string nombreObjetoEspecial; //Nombre del objeto especial

    void Start()
    {
        posicionOriginal = transform.position;
    }

    //collision.gameObject.name == "cubo"
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == nombreObjetoEspecial)
        {
            Vector3 posicionObjetoColisionado = collision.transform.position;//Obtenemos la posición del objeto que ha colisionado
            Vector3 posicionActual = transform.position;//Guardamos la posición actual del objeto
            transform.position = emptyObject.transform.position;//Movemos el objeto actual a la posición del GameObject Empty
            collision.transform.position = emptyObject.transform.position;//Movemos el objeto que ha colisionado al centro del GameObject Empty
            transform.position = posicionActual;//Restablecemos la posición del objeto a la posición original
            /*EXPLICACION
             * Se guarda la posición original del objeto antes de que se produzca la colisión, y luego 
             * se establece la posición de nuevo a la posición original en cada colisión. 
             */

            //Desactivamos el Rigidbody del objeto que ha colisionado
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            /*EXPLICACION
             * Se desactivando el componente de Rigidbody del objeto que ha colisionado después de moverlo al centro del GameObject Empty.
             */
        }
        else
        {
            // Si el objeto que ha colisionado no es el objeto especial, lo rechazamos
            Debug.Log("¡Objeto incorrecto!");
        }
    }
}