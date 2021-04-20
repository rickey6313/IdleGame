using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionTwoBehaviour : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlayerInputManager.instance.canReceiveInput = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(PlayerInputManager.instance.inputReceived)
        {
            int action = animator.GetInteger("Action");
            int actionNum = animator.GetInteger("ActionNum");
            action = 1;
            actionNum++;
            animator.SetInteger("Action", action);
            animator.SetInteger("ActionNum", actionNum);
            animator.SetTrigger("Trigger");
            PlayerInputManager.instance.InputManager();
            PlayerInputManager.instance.inputReceived = false;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (PlayerInputManager.instance.actionNum > 2)
            PlayerInputManager.instance.actionNum = 0;
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
