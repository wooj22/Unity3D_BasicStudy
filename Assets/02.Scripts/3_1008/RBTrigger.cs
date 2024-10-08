using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 과제 2. 오브젝트 Trigger 디버그
// 과제 3. 오브젝트 Trigger 충돌시 상대 오브젝트 Destroy()
public class RBTrigger : MonoBehaviour
{
    // 오브젝트가 겹쳐지는 순간
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter : " + other.gameObject.name);
        //Destroy(other.gameObject);
    }

    // 오브젝트가 겹쳐져있는 동안
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTriggerStay");
    }

    // 오브젝트가 분리되는 순간
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit : " + other.gameObject.tag);
    }
}
