//using System;
//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEditor;
//using UnityEngine;
//using UnityEngine.Experimental.GlobalIllumination;
//using UnityEngine.UIElements;

//public class NPCFov : MonoBehaviour
//{
//    private void OnDrawGizmos()
//    {
//        Gizmos.color = Color.yellow;
//        //Gizmos.DrawWireSphere(transform.position, 20);
//        Vector3 testRot = Quaternion.Euler(-5,-30, 0) * Vector3.back;
//        Vector3 testRot2 = Quaternion.Euler(7, -60, 0) * Vector3.back;

//        Handles.color = Color.blue;
//        Handles.DrawSolidArc(transform.position, Vector3.up, testRot, 60, 20);

//        Vector3 startPoint = transform.position + (Quaternion.Euler(-5, 0, 0) * Vector3.back * 23f);
//        Vector3 endPoint = transform.position + (Quaternion.Euler(55, 0, 0) * Vector3.back * 23f);

//        Vector3 arcCenter = (startPoint + endPoint) / 2f;
//        Handles.DrawLine(transform.position, arcCenter);
//        Vector3 endPosition = transform.position + Vector3.back * 19.9f;
//        endPosition.y = -0.001f;
//        Handles.DrawLine(transform.position, endPosition);
//        Vector3 arcCenter2 = (arcCenter + endPosition) / 2f; //¹ÝÀ¸·Î Á×¾î
//        Vector3 test = transform.position;
//        test.y = -0.1f;
//        Handles.DrawWireArc(test, testRot2, Vector3.back, 35, 20);
//        //Handles.DrawWireArc(transform.position,arcCenter,endPosition,60,20);
//    }
//}