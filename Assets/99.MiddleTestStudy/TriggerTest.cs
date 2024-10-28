using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            Debug.Log("Å¥ºê¿Í ´êÀ½");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            Debug.Log("Å¥ºê¿Í ´ê°íÀÖÀ½");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            Debug.Log("Å¥ºê¿Í ¶³¾îÁü");
        }
    }
}
