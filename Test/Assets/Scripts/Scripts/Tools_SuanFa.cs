using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tools_SuanFa
{

    //冒泡排序
    //从第0个元素开始和相邻的数字比较，小的数放前面，一直到n-1个数。
    public static void bubble_Sort(int[] test)
    {
        for (int i = 0; i <test.Length-1; i++)
        {
            for (int m = i+1; m < test.Length; m++)
            {

                if(test[i]>test[m])
                {
                    int desktop = test[i];
                    test[i] = test[m];
                    test[m] = desktop;
                }
            }
        }

        for (int i = 0; i < test.Length; i++)
        {

            Debug.Log(test[i] + "///" + i);

        }
    
    }


    //插入排序
    //从下标1开始和前面的数字比较小的数字插到前面，直到最后一个数字n。
    public static void insertion_sort(int[] test)
    {
        
        for (int i = 0; i < test.Length-1; i++)
        {

            for (int m = i+1; test[m] < test[m-1]; m--)
            {
                Debug.Log("//m" + m);
                int desk = test[m-1];
                test[m-1] = test[m];
                test[m] = desk;
                if(m==1)
                {
                    m++;
 //防止m==1后 m--时m等于0 和前面的下标为负时报错，也再一次比较0和1下标元素的大小
                }
            }
        }

        for (int i = 0; i < test.Length; i++)
        {
            Debug.Log(test[i] + "///" + i+"插入排序");

        }
    }

    //选择排序

    public static void selection_sort(int[] test)
    {

    }


    //快速排序

    public static void Quicksort(int[] test)
    {




    }

}
