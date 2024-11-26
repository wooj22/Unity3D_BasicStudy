using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPBar : MonoBehaviour
{
    Camera uiCamera;
    Canvas canvas;
    RectTransform rectParent;
    RectTransform rectHP;
    public Vector3 offset = Vector3.zero;
    public Transform targetTr;

    private void Start()
    {
        canvas = GetComponentInParent<Canvas>();
        uiCamera = canvas.worldCamera;
        rectParent = canvas.GetComponent<RectTransform>();
        rectHP = gameObject.GetComponent<RectTransform>();
    }

    private void LateUpdate()
    {
        // 스크린 좌표 변환
        Vector3 screenPos = Camera.main.WorldToScreenPoint(targetTr.position + offset);

        if (screenPos.z < 0.0f)
            screenPos *= -1.0f;

        Vector2 localPos = Vector2.zero;

        // RectTransform 좌표 변환
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectParent, screenPos, uiCamera, out localPos);

        // HP바 위치 변경
        rectHP.localPosition = localPos;
    }
}
