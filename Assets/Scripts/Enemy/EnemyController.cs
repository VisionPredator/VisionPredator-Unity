using UnityEngine;

/// <summary>
/// 적의 상태를 바꾸는 건 여기서 처리한다.
/// 
/// 김예리나 작성
/// </summary>

public enum NormalNPCState
{
    Idle,
    Move,
    Run,
    Death
}

public class EnemyController : MonoBehaviour
{
    private EnemyStateMachine<NormalNPCState> stateMachine;
    private TestBehavior testBehavior;
    public bool isDetectPlayer = false;

    public Transform player;

    public Vector3 center;
    //Do not change value
    public float radius => 30; //범위
    public float viewAngle => 20; //각도

    public float halfViewAngle;

    public GameObject eyeOne;

    public bool isdetectX = false;
    public bool isdetectY = false;
    private void Start()
    {
        stateMachine = new EnemyStateMachine<NormalNPCState>();
        stateMachine.Initialize(NormalNPCState.Idle);

        stateMachine.AddState(NormalNPCState.Idle, () =>
        {
            Debug.Log("Idle 상태");
        });

        stateMachine.AddState(NormalNPCState.Move, () =>
        {
            Debug.Log("Move 상태.");
        });

        stateMachine.AddState(NormalNPCState.Run, () =>
        {
            Debug.Log("Run 상태.");
        });

        stateMachine.AddState(NormalNPCState.Death, () =>
        {
            Debug.Log("Death 상태.");
        });

        testBehavior = GetComponent<TestBehavior>();



    }

    private void Update()
    {
        // Update the current state
        stateMachine.UpdateCurrentState();
        DetectedPlayer();
        center = eyeOne.transform.position;
        halfViewAngle = viewAngle / 2f; //여기맞나? 원래 스타트였긴함
    }

    /// <summary>
    /// 상시로 검사되는 1차 범위
    /// 완전 엉망진창
    /// </summary>
    public void DetectedPlayer()
    {
        float distanceToCenter = Vector3.Distance(player.position, center);

        if (distanceToCenter <= radius)
        {
            //Debug.Log("일단 원 안에 들어왔다. 좋아 여기까진 된다.");



            ///길이
            Vector3 toPlayerFlat = player.position - center;
            toPlayerFlat.y = 0; //y 축을 고려하지 않겠다.

            float angleToPlayerX = Vector3.Angle(toPlayerFlat, Vector3.forward) * Mathf.Deg2Rad;

            float halfDetectionAngleRadX = 30f * Mathf.Deg2Rad / 2f;

            if (angleToPlayerX <= halfDetectionAngleRadX)
            {
                //Debug.Log("제발 걸려라 x 시야범위 걸림");
                isdetectX = true;
            }
            else
            {
                isdetectX = false;

            }

            Vector3 toPlayerFlatY = player.position - center;
            toPlayerFlatY.x = 0;

            ///높이
            //y축의 각도를 바꾸어 두어서 이부분이 필요했다. 
            Quaternion yRotationOffset = Quaternion.Euler(-5f, 0f, 0f); // y축 시야 벡터의 각도 오프셋 (5도)
            Vector3 rotatedToPlayerFlatY = yRotationOffset * toPlayerFlatY; // 회전된 y축 시야 벡터
            float angleToPlayerY = Vector3.Angle(rotatedToPlayerFlatY, Vector3.forward) * Mathf.Deg2Rad;
            //float angleToPlayerY = Vector3.Angle(toPlayerFlatY, Vector3.forward) * Mathf.Deg2Rad;
            float halfDetectionAngleRadY = 20f * Mathf.Deg2Rad / 2f;

            if (angleToPlayerY <= halfDetectionAngleRadY)
            {
                //Debug.Log("y축 시야 범위 내에 있습니다.");
                isdetectY = true;
            }
            else
            {
                isdetectY = false;

            }

            if (isdetectX && isdetectY)
            {
                isDetectPlayer = true;
                Debug.Log("걸리는중");
                stateMachine.ChangeState(NormalNPCState.Run);
                testBehavior.m_Animator.SetBool("Run",true);
            }
        }
        else
        {
            isdetectX = false;
            isdetectY = false;
            isDetectPlayer = false;
            //testBehavior.m_Animator.SetBool("Move", true);

        }
    }
}
