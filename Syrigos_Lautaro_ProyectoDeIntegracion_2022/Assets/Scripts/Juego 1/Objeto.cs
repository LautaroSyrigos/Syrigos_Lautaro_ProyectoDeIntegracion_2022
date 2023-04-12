using UnityEngine;

public class Objeto : MonoBehaviour
{
    public bool SePuedeAgarrar = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponentInParent<MecanicaAgarrarObjetos>().ObjetoParaAgarrar = this.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        other.GetComponentInParent<MecanicaAgarrarObjetos>().ObjetoParaAgarrar = null;
    }
}
