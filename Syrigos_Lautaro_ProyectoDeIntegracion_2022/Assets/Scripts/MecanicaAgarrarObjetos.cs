using UnityEngine;

public class MecanicaAgarrarObjetos : MonoBehaviour
{
    [Header("Variables")]
    public GameObject Manos;
    private GameObject ObjetoEnMano = null;

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
    }
}