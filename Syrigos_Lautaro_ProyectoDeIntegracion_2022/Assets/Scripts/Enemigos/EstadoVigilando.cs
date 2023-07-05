using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EstadoVigilando : StateMachineBehaviour
{
    private float Temporizador;
    private List<Transform> PuntosReferencias = new List<Transform>();
    private NavMeshAgent agent;

    private Transform TransformDelJugador;
    private float RangoPersecucion = 10f;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Temporizador = 0;
        Transform PuntosDeReferenciaObjectos = GameObject.FindGameObjectWithTag("PuntoReferencia").transform;
        foreach (Transform t in PuntosDeReferenciaObjectos)
        {
            PuntosReferencias.Add(t);
        }
        agent = animator.GetComponent<NavMeshAgent>();
        agent.SetDestination(PuntosReferencias[0].position);

        TransformDelJugador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent.remainingDistance <= agent.stoppingDistance)
            agent.SetDestination(PuntosReferencias[Random.Range(0, PuntosReferencias.Count)].position);
        Temporizador += Time.deltaTime;
        if (Temporizador > 5)
        {
            animator.SetBool("EstaVigilando", false);
        }
        float Distancia = Vector3.Distance(animator.transform.position, TransformDelJugador.position);
        if (Distancia < RangoPersecucion)
        {
            animator.SetBool("EstaPersiguiendo", true);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
