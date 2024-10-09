using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� 4. ������Ʈ Collision �����
// ���� 5. ������Ʈ Collision �浹�� ��� ������Ʈ Destroy()
public class RBCollision : MonoBehaviour
{
    // ������Ʈ�� �����ϴ� ����
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter : " + collision.gameObject.name);
        //Destroy(collision.gameObject, 2f);
    }

    // ������Ʈ�� ������ ����
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("OnCollisionStay");
    }

    // ������Ʈ�� �������� ����
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("OnCollisionExit : " + collision.gameObject.tag);
    }
}

/*
// ����/�Ϲ� ������Ʈ �浹 ����
1. Collision �̺�Ʈ (OnCollisionEnter, OnCollisionStay, OnCollisionExit):
 - �� ������Ʈ ��� Collider
 - ��� �ϳ��� ������Ʈ�� Rigidbody
 - IsTrigger Off, isKinematic OFF (��������ޱ�)
 - ������ �浹�� ó���ϴ� �� ���
 - ���� ���, �� ���� ��ü�� ���� �ε��� ���� ����(�浹 ����, ��, ���� ��)�� ����
 - ���� ������ ���� ��Ģ�� ���� �۵��ϹǷ�, �������� ������ ��

2. Trigger �̺�Ʈ (OnTriggerEnter, OnTriggerStay, OnTriggerExit):
 - �� ������Ʈ ��� Collider
 - ��� �ϳ��� ������Ʈ�� Rigidbody
 - IsTrigger On
 - �񹰸��� ��ȣ�ۿ�
 - ���� ���, Ư�� ������ ���� ���� �̺�Ʈ(���� ����, ������ ȹ�� ��)�� �����ϰ� ó��
 - ������ �浹�� �ƴ� ���� ��ȭ�� �����ϱ� ������, �� �����ϰ� ��밡��
 */