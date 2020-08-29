using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuanFa : MonoBehaviour {

    // Use this for initialization

    int[] sort_Test;
	void Start ()
    {
        sort_Test = new int[] {10,1,20,2,30,3,50,5,60,6 };
	}
	
	// Update is called once per frame
	void Update ()
    {
	 if (Input.GetKeyDown(KeyCode.Space))
        {
            //Tools_SuanFa.bubble_Sort(sort_Test);x
            Tools_SuanFa.insertion_sort(sort_Test);
        }
	}
}
