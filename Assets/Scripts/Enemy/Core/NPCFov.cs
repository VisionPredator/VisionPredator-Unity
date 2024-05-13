using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UIElements;

/// <summary>
/// 적들이 공유할..지도 모르는 시야 범위를 그리는 기즈모
/// 에디터를 안쓴 이유 : 거기까지 할 필요를 결국 못느꼈다 계속 기즈모랑 핸들이랑 고민했는데 모르겠다
/// 
/// 김예리나 작성
/// </summary>
public class NPCFov : MonoBehaviour
{
    public EnemyController enemyController;

    private void Start()
    {
        enemyController = GetComponentInParent<EnemyController>();
    }
    //하드코딩을 줄여야하는데..함수로 빼도 의미가 없어보임
    private void OnDrawGizmos()
    {

        Quaternion leftRotation = Quaternion.Euler(0, -enemyController.halfViewAngle, 0f);
        Quaternion rightRotation = Quaternion.Euler(0, enemyController.halfViewAngle, 0f);

        Quaternion leftRotation2 = Quaternion.Euler(-enemyController.halfViewAngle + 5, 0, 0f);
        Quaternion rightRotation2 = Quaternion.Euler(enemyController.halfViewAngle + 5, 0, 0f);

        Vector3 leftVector = leftRotation * Vector3.forward;
        Vector3 rightVector = rightRotation * Vector3.forward;

        Vector3 leftVector2 = leftRotation2 * Vector3.forward;
        Vector3 rightVector2 = rightRotation2 * Vector3.forward;

        //전체 범위
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(enemyController.center, enemyController.radius);

        //가로선
        Gizmos.color = Color.red;
        Gizmos.DrawRay(enemyController.center, leftVector * enemyController.radius);
        Gizmos.DrawRay(enemyController.center, rightVector * enemyController.radius);
        //세로
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(enemyController.center, leftVector2 * enemyController.radius);
        Gizmos.DrawRay(enemyController.center, rightVector2 * enemyController.radius);
    }
}