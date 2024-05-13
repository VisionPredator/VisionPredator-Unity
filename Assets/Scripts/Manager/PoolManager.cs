using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

/// <summary>
/// Object를 빠르게 생성하고 삭제해야 할 때 Project를 최적화하고 CPU에 가해지는 부담을 낮추는 방법인 Class
/// </summary>
public class PoolManager : MonoBehaviour
{ 
    // Object Pool
    private ObjectPool<GameObject> objectPool;

    public int initalizeCapacity = 0;   /// 초기 용량이자 Default 용량 
    public int maxCapacity = 10;        /// 최대 용량 

    private int count = 0;              /// Get과 Return 할 때 Check 해주는 변수

    /// <summary>
    /// Object들을 관리하기 위해 꼭 필요한 초기 단계이다.
    /// </summary>
    /// <param name="_objectPrefab">Pool Manager에 적용할 GameObject</param>
    public void InitalizeObjectPool(GameObject _objectPrefab)
    {
        // Lamda로 만들었다.
        objectPool = new ObjectPool<GameObject>(
                    createFunc: () => Instantiate(_objectPrefab),       // ObjectPool을 생성
                    actionOnGet: (obj) => obj.SetActive(true),          // Object를 Get을 해서 모든 Object가 true인데 Get을 하면 하나 생성한다.
                    actionOnRelease: (obj) => obj.SetActive(false),     // Object를 Release를 해서 true가 되었던 Object를 false 한다.
                    actionOnDestroy: (obj) => Destroy(obj),             // Object를 삭제한다.
                    defaultCapacity: initalizeCapacity,                 // Default 용량 설정
                    maxSize: maxCapacity                                // 최대 용량 설정
                );
    }

    /// <summary>
    /// Object를 가져온다.
    /// </summary>
    /// <returns>초기 단계 넣은 GameObject</returns>
    public GameObject GetPool()
    {
        count++;

        // 현재 count가 Object의 최대치보다 높아지면 null을 반납한다.
        if (count > maxCapacity)
        {
            // count = Max 최대치
            count = maxCapacity;
            return null;
        }

        // 그게 아니면 Object Pool에서 뱉어낸다. -> SetActive(true) 전에 없다면 하나 만든다.
        return objectPool.Get();
    }

    /// <summary>
    /// Object를 반납한다.
    /// </summary>
    /// <param name="bullet">반납할 GameObject</param>
    public void ReturnPool(GameObject _gameObject)
    {
        count--;

        // object를 반납한다. -> setActive(false)로 한다.
        objectPool.Release(_gameObject);
    }
}