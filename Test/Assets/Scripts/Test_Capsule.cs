using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Capsule : MonoBehaviour
{
    void Start()
    {

    }
    public Transform transform_Tagert;
    void Update()
    {
        transform.LookAt(transform_Tagert);
    }
}
