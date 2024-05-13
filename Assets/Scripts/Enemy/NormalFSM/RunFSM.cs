using Gamekit3D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Run 상태의 FSM 상태
/// 
/// 김예리나 작성
/// </summary>
public class RunFSM : SceneLinkedSMB<TestBehavior>
{

    public override void OnSLStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_MonoBehaviour.SetRandomTargetPosition();
        Debug.Log("도망상태 들어옴");
    }
    public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("도망촤~~");
        m_MonoBehaviour.MoveRun();

    }
}
