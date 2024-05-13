using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum FillMethodType
{
    Vertical,
    Horizontal,
    Radial90,
    Radial180,
    Radial360,
}

public class HPGauge : MonoBehaviour
{
    public Image image;         // 해당 이미지
    public float speed;         // 줄어드는 속도

    void Start()
    {
        speed = 0.1f;
        image.type = Image.Type.Filled;
        image.fillAmount = 1.0f;
        image.fillMethod = Image.FillMethod.Vertical;
        image.fillOrigin = (int)Image.OriginVertical.Bottom;
    }

    void Update()
    {
        SelectKey();

        if(Input.GetKey(KeyCode.T))
        {
            image.fillAmount += speed * Time.deltaTime * 2;
        }

        if(Input.GetKey(KeyCode.Y)) 
        {
            image.fillAmount -= speed * Time.deltaTime;
        }

        if(image.fillAmount < 0.0f)
        {
            // Game Over UI 넣자.
        }

    }

    void SelectKey()
    {
        // 해당 이미지 채우기
        if (Input.GetKeyDown(KeyCode.R))
        {
            image.fillAmount = 1.0f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectFillMethodType(FillMethodType.Vertical);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SelectFillMethodType(FillMethodType.Horizontal);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SelectFillMethodType(FillMethodType.Radial90);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SelectFillMethodType(FillMethodType.Radial180);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SelectFillMethodType(FillMethodType.Radial360);
        }
    }

    void SelectFillMethodType(FillMethodType type)
    {
        switch (type) 
        {
            case FillMethodType.Vertical:
                image.fillMethod = Image.FillMethod.Vertical;
                break;
            case FillMethodType.Horizontal:
                image.fillMethod = Image.FillMethod.Horizontal;
                break;
            case FillMethodType.Radial90:
                image.fillMethod = Image.FillMethod.Radial90;
                break;
            case FillMethodType.Radial180:
                image.fillMethod = Image.FillMethod.Radial180;
                break;
            case FillMethodType.Radial360:
                image.fillMethod = Image.FillMethod.Radial360;
                break;
        }
    }
}
