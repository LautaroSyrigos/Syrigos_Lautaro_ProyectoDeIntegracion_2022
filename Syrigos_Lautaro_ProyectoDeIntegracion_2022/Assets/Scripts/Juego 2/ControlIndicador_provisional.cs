using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlIndicador_provisional : MonoBehaviour
{
    Transform LuzTransform;
    [SerializeField]int VelocidadDeMovimiento;

    void Start()
    {
        LuzTransform = gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        float MovimientoHorizontal = Input.GetAxis("Horizontal");
        float MovimientoVertical = Input.GetAxis("Vertical");
        Vector3 MovimientoDeLaLuz = new Vector3(MovimientoHorizontal, 0, MovimientoVertical);
        LuzTransform.position += MovimientoDeLaLuz.normalized * VelocidadDeMovimiento * Time.deltaTime;
    }
}
