using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoIdle : StateMachineBehaviour
{
    private float Temporizador;
    // OnStateEnter se llama cuando comienza una transición y la máquina de estado comienza a evaluar este estado.
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Temporizador = 0;
    }

    // OnStateUpdate se llama en cada marco de actualización entre las devoluciones de llamada OnStateEnter y OnStateExit.
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Temporizador += Time.deltaTime;
        if(Temporizador > 2) 
        {
            animator.SetBool("EstaVigilando", true);
        }
    }

    // OnStateExit se llama cuando finaliza una transición y la máquina de estado termina de evaluar este estado.
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

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
