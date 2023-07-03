using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    public GameObject Objetivo;
    public NavMeshAgent Agent;
    public temp_06 VidaScript;
    public float Distancia;

    private void Update()
    {
        if (Vector3.Distance(Objetivo.transform.position, transform.position)<Distancia)
        {
            Agent.SetDestination(Objetivo.transform.position);
            Agent.speed = 3;
        }
        else
        {
            Agent.speed = 0;
        }

        if (Vector3.Distance(Objetivo.transform.position, transform.position) <= 2)
        {
            VidaScript.health = VidaScript.health - 10;
        }
    }
}
