using Gamekit3D;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;

/// <summary>
/// 세부적인 행동을 하는 클래스
/// 적들말이야 적들! 
///
/// 김예리나 작성
/// </summary>
[DefaultExecutionOrder(100)] //속성, 나중에 실행되라고 하는 것이다.
public class TestBehavior : MonoBehaviour
{
    public Animator m_Animator;
    //public Animator animator { get { return m_Animator; } }
    // Start is called before the first frame update
    private Vector3 targetPosition; 

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        SceneLinkedSMB<TestBehavior>.Initialise(m_Animator, this);
        //SetRandomTargetPosition();
    }

    public void MoveRun()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, 10 * Time.deltaTime);
    }
    public void SetRandomTargetPosition()
    {
        ///
        float randomX = Random.Range(-500f, 500f);
        //float randomY = Random.Range(-5f, 5f);
        float randomZ = Random.Range(-500f, 500f);
        targetPosition = new Vector3(randomX, 0, randomZ);
    }
}
