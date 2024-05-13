using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro.EditorUtilities;
using Unity.VisualScripting;

public class Healkit : MonoBehaviour
{
    // UI Test 할 거
    public Image backGround;
    public TMP_Text title;

    public Image backGround2;
    public TMP_Text explanation;

    public Image backGround3;
    public TMP_Text pickUp;

    public Player player;
    public Vector3 UIPosition;

    // 설명 창이 띄워진다.
    bool isSetting;
    // 아이템이 먹어졌으면 실행한다.
    bool isPickup;

    void Start()
    {
        Initalize();
    }

    /// 거리 비례로 크기가 줄었다 커졌다 해야될 거 같아.
    private void Update()
    {
        if (player.IsTargetVisible(transform))
        {
            if (player.IsRayTarget(transform))
            {
                title.text = "구급 상자";
                title.transform.position = Camera.main.WorldToScreenPoint(transform.position + UIPosition);
                backGround.transform.position = Camera.main.WorldToScreenPoint(transform.position + UIPosition);
                backGround.color = new Color(0.0f, 0.0f, 0.0f, 0.5f);

                if (isSetting)
                {
                    explanation.text = "체력을 10 회복합니다.";
                    explanation.transform.position = Camera.main.WorldToScreenPoint(transform.position - UIPosition);
                    backGround2.transform.position = Camera.main.WorldToScreenPoint(transform.position - UIPosition);
                    backGround2.color = new Color(0.0f, 0.0f, 0.0f, 0.5f);
                    explanation.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
                }
                else
                {
                    explanation.text = "";
                    backGround2.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
                }
            }
            else
            {
                title.text = "";
                backGround.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            }
        }
        else
        {
            title.text = "";
            backGround.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 7은 여기서 Player다.
        if(collision.gameObject.layer == 7)
        {
            // 닿았으면 뭔가 해야 하는데 ??
            // 아이템이 먹은 거니까
            gameObject.SetActive(false);
            isPickup = true;
            // 먹었을 때 나오는 UI
            backGround3.color = new Color(0.0f, 0.0f, 0.0f, 0.5f);
            pickUp.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            pickUp.text = "체력을 10 회복합니다.";
            Invoke("DestoryText", 3.0f);
        }
    }

    // 초기치
    private void Initalize()
    {
        backGround.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        backGround2.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        backGround3.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        
        title.text = "";
        title.fontSize = 18;
        explanation.fontSize = 10;
        pickUp.fontSize = 10;

        title.color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
        title.alignment = TextAlignmentOptions.Center;
        explanation.alignment = TextAlignmentOptions.Center;
        pickUp.alignment = TextAlignmentOptions.Center;
        UIPosition.y = 0.3f;
    }

    // item object에다가 이것을 넣을 것이다.
    private void OnMouseEnter()
    {
        isSetting = true;
    }

    private void OnMouseExit()
    {
        isSetting = false;
    }

    void DestoryText()
    {
        backGround3.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        pickUp.color = new Color(1.0f, 0.0f, 0.0f, 0.0f);
        pickUp.text = "";
    }
}
