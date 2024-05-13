using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookAt : MonoBehaviour
{
    public GameObject cam;          // 카메라
    public GameObject item;         // 아이템

    public Image image;

    public Vector3 offset;          // Object UI 위치
    private Vector3 startScale;     // 초기 scale 저장
    private Vector3 startOffset;    // 초기 위치

    private float localScaleDistance = 80f;
    public float positionDistance = 80f;

    // Start is called before the first frame update
    void Start()
    {
        offset.y = 2.0f;
        startScale = transform.localScale;
        startOffset = offset;
    }

    private void Update()
    {
        float dist = Vector3.Distance(cam.transform.position, transform.position);
        Vector3 newScale = startScale * dist / localScaleDistance;
        Vector3 newOffset = offset * dist / positionDistance;

        transform.position = item.transform.position + newOffset;
        transform.rotation = cam.transform.rotation;
        transform.localScale = newScale;
    }
}
