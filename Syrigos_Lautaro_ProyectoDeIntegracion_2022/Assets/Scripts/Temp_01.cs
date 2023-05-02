using UnityEngine;

public class Temp_01 : MonoBehaviour
{
    private bool agarrando;
    private GameObject objetoAgarrado;
    private Rigidbody rbAgarrado;

    // Etiqueta de los objetos que se pueden agarrar
    public string etiquetaAgarrable = "Agarrar";

    // GameObject vacío que representa las manos del personaje
    public GameObject manos;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            if (!agarrando)
            {
                AgarrarObjeto();
            }
            else
            {
                SoltarObjeto();
            }
        }
    }

    void AgarrarObjeto()
    {
        // Realiza una esfera de colisión centrada en las manos del personaje y con un radio de 0.1f
        Collider[] colliders = Physics.OverlapSphere(manos.transform.position, 0.1f);

        foreach (Collider collider in colliders)
        {
            // Si el objeto es agarrable
            if (collider.gameObject.CompareTag(etiquetaAgarrable))
            {
                // Agarra el objeto
                objetoAgarrado = collider.gameObject;
                rbAgarrado = objetoAgarrado.GetComponent<Rigidbody>();
                rbAgarrado.useGravity = false;
                rbAgarrado.isKinematic = true;
                objetoAgarrado.transform.position = manos.transform.position;
                objetoAgarrado.transform.parent = manos.transform;
                agarrando = true;
                break;
            }
        }
    }

    void SoltarObjeto()
    {
        // Suelta el objeto
        objetoAgarrado.transform.parent = null;
        rbAgarrado.useGravity = true;
        rbAgarrado.isKinematic = false;
        objetoAgarrado = null;
        rbAgarrado = null;
        agarrando = false;
    }
}

/*EXPLICACION:
 * Este código utiliza el método Physics.OverlapSphere para realizar una esfera de colisión centrada 
 * en las manos del personaje y con un radio de 0.1f. Si un objeto con la etiqueta "Grabbable" se 
 * encuentra dentro de esta esfera, entonces el jugador lo puede agarrar.
 * ------------------------------------------------------------------------------------------------
 * Al presionar la tecla "E", si el jugador no está agarrando ningún objeto, el script busca un objeto 
 * agarrable dentro de la esfera de colisión. Si se encuentra un objeto, se agrega a la mano del jugador 
 * y se desactiva su gravedad y físicas para que pueda ser manipulado correctamente. Si el jugador vuelve 
 * a presionar la tecla "E" mientras está agarrando un objeto, entonces este se suelta y se reactivan las 
 * físicas del objeto.
 */

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Temp_01 : MonoBehaviour
{
    private GameObject ObjetoEnMano;
    private Transform Manos;
    private float tiempoUltimaPulsacion = 0f;
    private float tiempoDoblePulsacion = 0.5f;

    void Update()
    {
        if (ObjetoEnMano != null)
        {
            if (Input.GetKeyDown(KeyCode.Space) && (Time.time - tiempoUltimaPulsacion) > tiempoDoblePulsacion)
            {
                ObjetoEnMano.GetComponent<Rigidbody>().useGravity = true;
                ObjetoEnMano.GetComponent<Rigidbody>().isKinematic = false;
                ObjetoEnMano.transform.position = Manos.transform.position;
                ObjetoEnMano.gameObject.transform.SetParent(null);
                ObjetoEnMano = null;
                tiempoUltimaPulsacion = Time.time;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Agarrar"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (ObjetoEnMano == null)
                {
                    other.GetComponent<Rigidbody>().useGravity = false;
                    other.GetComponent<Rigidbody>().isKinematic = true;
                    other.transform.position = Manos.transform.position;
                    other.gameObject.transform.SetParent(Manos.gameObject.transform);
                    ObjetoEnMano = other.gameObject;
                    tiempoUltimaPulsacion = Time.time;
                }
                else if (ObjetoEnMano == other.gameObject && (Time.time - tiempoUltimaPulsacion) < tiempoDoblePulsacion)
                {
                    ObjetoEnMano.GetComponent<Rigidbody>().useGravity = true;
                    ObjetoEnMano.GetComponent<Rigidbody>().isKinematic = false;
                    ObjetoEnMano.transform.position = Manos.transform.position;
                    ObjetoEnMano.gameObject.transform.SetParent(null);
                    ObjetoEnMano = null;
                    tiempoUltimaPulsacion = 0f;
                }
            }
        }
    }
    */

/*
public Transform Manos;
private GameObject _grabbedObject;
private Vector3 _grabOffset;

private void Update()
{
    if (Input.GetButtonDown("G"))
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
        {
            if (hit.collider.CompareTag("Agarrar"))
            {
                _grabbedObject = hit.collider.gameObject;
                _grabbedObject.transform.parent = Manos;
                _grabOffset = _grabbedObject.transform.position - hit.point;
            }
        }
    }

    if (Input.GetButtonUp("G"))
    {
        _grabbedObject = null;
    }

    if (_grabbedObject != null)
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 10.0f;
        _grabbedObject.transform.position = Camera.main.ScreenToWorldPoint(mousePosition) + _grabOffset;
    }
}

/*
[SerializeField] private Transform handTransform;
private Rigidbody heldObject;
private FixedJoint joint;
private int clickCount;

void Update()
{
    if (Input.GetKeyDown(KeyCode.Space))
    {
        if (heldObject == null)
        {
            // Si no se está sosteniendo un objeto, detecta un objeto con un Rigidbody dentro de un cierto rango
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2f);
            foreach (Collider hitCollider in hitColliders)
            {
                if (hitCollider.attachedRigidbody != null && hitCollider.attachedRigidbody != GetComponent<Rigidbody>())
                {
                    heldObject = hitCollider.attachedRigidbody;
                    joint = handTransform.gameObject.AddComponent<FixedJoint>();
                    joint.connectedBody = heldObject;
                    heldObject.transform.position = handTransform.position;
                    heldObject.transform.rotation = handTransform.rotation;
                    heldObject.useGravity = false;
                    clickCount = 1;
                    break;
                }
            }
        }
        else
        {
            // Si se está sosteniendo un objeto, soltarlo
            clickCount++;
            if (clickCount == 2)
            {
                Destroy(joint);
                heldObject.useGravity = true;
                heldObject = null;
                clickCount = 0;
            }
        }
    }
}

/*
private Rigidbody heldObject;
private FixedJoint joint;
private int clickCount;

void Update()
{
    if (Input.GetKeyDown(KeyCode.Space))
    {
        if (heldObject == null)
        {
            // Si no se está sosteniendo un objeto, detecta un objeto con un Rigidbody dentro de un cierto rango
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2f);
            foreach (Collider hitCollider in hitColliders)
            {
                if (hitCollider.attachedRigidbody != null && hitCollider.attachedRigidbody != GetComponent<Rigidbody>())
                {
                    heldObject = hitCollider.attachedRigidbody;
                    joint = gameObject.AddComponent<FixedJoint>();
                    joint.connectedBody = heldObject;
                    heldObject.useGravity = false;
                    clickCount = 1;
                    break;
                }
            }
        }
        else
        {
            // Si se está sosteniendo un objeto, soltarlo
            clickCount++;
            if (clickCount == 2)
            {
                Destroy(joint);
                heldObject.useGravity = true;
                heldObject = null;
                clickCount = 0;
            }
        }
    }
}*/