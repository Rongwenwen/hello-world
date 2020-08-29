using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Testo2 : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }
    public RawImage image_;
    public void Test_Fun()
    {
        image_.texture = File_Test.tex;
    }
    void disable()
    {
        this.gameObject.SetActive(false);
        image_.texture = null;
    }
}
