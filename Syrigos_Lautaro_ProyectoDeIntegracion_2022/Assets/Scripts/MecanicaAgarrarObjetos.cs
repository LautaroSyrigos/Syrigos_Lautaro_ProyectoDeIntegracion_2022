using UnityEngine;

public class MecanicaAgarrarObjetos : MonoBehaviour
{
    public GameObject ObjetoParaAgarrar;
    GameObject ObjetoEnMano;
    public Transform Manos;

    public new AudioClip audio;

    void Update()
    {
        if (ObjetoParaAgarrar != null && ObjetoParaAgarrar.GetComponent<Objeto>().SePuedeAgarrar == true && ObjetoEnMano == null)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                AudioSource.PlayClipAtPoint(audio, transform.position);

                ObjetoEnMano = ObjetoParaAgarrar;
                ObjetoEnMano.GetComponent<Objeto>().SePuedeAgarrar = false;
                ObjetoEnMano.transform.SetParent(Manos);
                ObjetoEnMano.transform.position = Manos.position;
                ObjetoEnMano.GetComponent<Rigidbody>().useGravity = false;
                ObjetoEnMano.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                ObjetoEnMano.GetComponent<Objeto>().SePuedeAgarrar = true;
                ObjetoEnMano.transform.SetParent(null);
                ObjetoEnMano.GetComponent<Rigidbody>().useGravity = true;
                ObjetoEnMano.GetComponent<Rigidbody>().isKinematic = false;
                ObjetoEnMano = null;
            }
        }
    }

    /*VERSION ALTERNATIVA
    void Update()
    {
        if (ObjetoEnMano != null)
        {
            if (Input.GetKey("g"))
            {
                ObjetoEnMano.GetComponent<Rigidbody>().useGravity = true;
                ObjetoEnMano.GetComponent<Rigidbody>().isKinematic = false;
                ObjetoEnMano.transform.position = Manos.transform.position;
                ObjetoEnMano.gameObject.transform.SetParent(null);
                ObjetoEnMano = null;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Grabbable"))
        {
            if (Input.GetKey("f") && ObjetoEnMano == null)
            {
                other.GetComponent<Rigidbody>().useGravity = false;
                other.GetComponent<Rigidbody>().isKinematic = true;
                other.transform.position = Manos.transform.position;
                other.gameObject.transform.SetParent(Manos.gameObject.transform);
                ObjetoEnMano = other.gameObject;
            }
        }
    }*/
}