using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeTest : MonoBehaviour
{
    private void Start()
    {
        Invoke(nameof(Invoke2f), 2f);
        InvokeRepeating(nameof(InvokeRepeating1f2f), 1f, 2f);
    }

    private void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            CancelInvoke(nameof(Invoke2f));
        }
        else if (Input.GetKeyDown("2"))
        {
            CancelInvoke();
        }
    }

    void Invoke2f()
    {
        Debug.Log("Invoke2f");
    }

    void InvokeRepeating1f2f()
    {
        Debug.Log("InvokeRepeating1f2f");
    }

}
