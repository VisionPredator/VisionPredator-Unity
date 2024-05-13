using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFovSec : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        //2Â÷ ¹üÀ§
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 10);
    }
}
