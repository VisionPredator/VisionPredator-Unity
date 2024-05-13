using Gamekit3D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Walk 상태의 FSM 상태
/// 
/// 김예리나 작성
/// </summary>
//사실 저 StateMachineBehaviour는 ScriptObject를 상속받는다.
public class MoveFSM : SceneLinkedSMB<TestBehavior>
{
    public override void OnSLStateNoTransitionUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("무빙무빙중");
    }

}
