using UnityEngine;

/// <summary>
/// 적들이 공유하는 데미지 인터페이스
/// 함수가 하나뿐이지만 인터페이스로 구현해야했다. 또 생각이 바뀔수도
/// 
/// 김예리나 작성
/// </summary>
public interface IDamageable
{
    public void Damaged(int damage, Vector3 hitPoint, bool something);
}