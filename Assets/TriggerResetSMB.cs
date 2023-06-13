using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerResetSMB : StateMachineBehaviour
{
    [SerializeField] private string _triggerName;
    //OnStateExit is called before OnStateExit is called on any state inside this state machine
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger(_triggerName);
    }
}
