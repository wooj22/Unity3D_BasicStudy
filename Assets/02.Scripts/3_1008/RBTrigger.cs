using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� 2. ������Ʈ Trigger �����
// ���� 3. ������Ʈ Trigger �浹�� ��� ������Ʈ Destroy()
public class RBTrigger : MonoBehaviour
{
    // ������Ʈ�� �������� ����
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter : " + other.gameObject.name);
        //Destroy(other.gameObject);
    }

    // ������Ʈ�� �������ִ� ����
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay");
    }

    // ������Ʈ�� �и��Ǵ� ����
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit : " + other.gameObject.tag);
    }
}
