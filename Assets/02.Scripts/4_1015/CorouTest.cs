using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorouTest : MonoBehaviour
{
    private Coroutine st;

    private void Start()
    {
        st = StartCoroutine(ShowTime(1f, 2f));
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StopCoroutine(st);
            //StopAllCoroutines();
        }
    }

    IEnumerator ShowTime(float first, float repeat)
    {
        yield return new WaitForSeconds(first);
        Debug.Log(first + "초 경과");

        while(true){
            yield return new WaitForSeconds(repeat);
            Debug.Log(repeat + "초 경과");

            /*
            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log("Stop Coroutine");
                yield break;
            }
            */
        }
    }
}
