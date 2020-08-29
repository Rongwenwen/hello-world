using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_01 : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        test_02.unmber++;
        Debug.Log(this.gameObject.name + "当前物体名称"+"  数字"+test_02.unmber);
    }

    // Update is called once per frame
    void Update()
    {

    }
}