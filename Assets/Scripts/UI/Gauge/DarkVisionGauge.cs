using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarkVisionGauge : MonoBehaviour
{
    public AbsorbGauge absorbGauge;
    public Image image;         // 해당 이미지 지금은 Test 용도라서 아무거나 넣자
    public float speed;         // 차는 속도
    public float gauge;         // Gauge

    public bool isfull;        // Player 쪽에 있겠지 일단 Test니까 내가 만들어서 진행하자
    private int count;

    // public으로 말고 private로 받아오는 방법 없을까?
    public Player player;

    void Start()
    {
        count = 0;
        speed = 0.1f;
        gauge = 0.1f;
        image.type = Image.Type.Filled;
        image.fillAmount = 0.0f;
        image.fillMethod = Image.FillMethod.Vertical;
        image.fillOrigin = (int)Image.OriginVertical.Bottom;
    }

    void Update()
    {
        // Player에서 받아와야 한다.
        // Gage들은 Player의 정보를 알아와야 해
        if (Input.GetKeyDown(KeyCode.E))
        {
            count++;
        }

        if (((count * gauge) >= image.fillAmount) && !isfull)
        {
            image.fillAmount += speed * Time.deltaTime;

            if (image.fillAmount >= 1.0f)
            {
                isfull = true;
            }
        }

        if (isfull)
        {
            image.fillAmount -= speed * Time.deltaTime;

            if (image.fillAmount <= 0.0f)
            {
                isfull = false;
                count = 0;
            }
        }
    }
}
