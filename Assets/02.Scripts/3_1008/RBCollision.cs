using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 과제 4. 오브젝트 Collision 디버그
// 과제 5. 오브젝트 Collision 충돌시 상대 오브젝트 Destroy()
public class RBCollision : MonoBehaviour
{
    // 오브젝트가 접촉하는 순간
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter : " + collision.gameObject.name);
        //Destroy(collision.gameObject, 2f);
    }

    // 오브젝트가 접촉한 상태
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("OnCollisionStay");
    }

    // 오브젝트가 떨어지는 순간
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("OnCollisionExit : " + collision.gameObject.tag);
    }
}

/*
// 물리/일반 오브젝트 충돌 차이
1. Collision 이벤트 (OnCollisionEnter, OnCollisionStay, OnCollisionExit):
 - 두 오브젝트 모두 Collider
 - 적어도 하나의 오브젝트에 Rigidbody
 - IsTrigger Off, isKinematic OFF (물리영향받기)
 - 물리적 충돌을 처리하는 데 사용
 - 예를 들어, 두 개의 물체가 서로 부딪힐 때의 반응(충돌 반응, 힘, 마찰 등)을 구현
 - 물리 엔진의 물리 법칙에 따라 작동하므로, 실제적인 느낌을 줌

2. Trigger 이벤트 (OnTriggerEnter, OnTriggerStay, OnTriggerExit):
 - 두 오브젝트 모두 Collider
 - 적어도 하나의 오브젝트에 Rigidbody
 - IsTrigger On
 - 비물리적 상호작용
 - 예를 들어, 특정 지역에 들어갔을 때의 이벤트(게임 시작, 아이템 획득 등)를 감지하고 처리
 - 물리적 충돌이 아닌 상태 변화를 감지하기 때문에, 더 유연하게 사용가능
 */