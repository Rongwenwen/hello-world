using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_02 : MonoBehaviour
{

    // Use this for initialization

    public static int unmber;
    private void Awake()
    {

    }

    void Start()
    {
        unmber++;
        Debug.Log(this.gameObject.name + "当前物体名称"+"  数字"+unmber);
       
    }

    // Update is called once per frame
    void Update()
    {

    }
}
