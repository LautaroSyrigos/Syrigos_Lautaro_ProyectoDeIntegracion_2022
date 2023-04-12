using UnityEngine;
using UnityEngine.UI;

public class PilarInteractivo : MonoBehaviour
{
    public Image imageToDisplay;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            imageToDisplay.gameObject.SetActive(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            imageToDisplay.gameObject.SetActive(false);
        }
    }
}
