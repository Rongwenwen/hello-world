using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//实现list
public class List_m<T>
{
    //功能 增删改查
    [HideInInspector]
    public T[] Data;//数组
    [HideInInspector]
    public int index;//索引

    public List_m()
    {
        //List_m<T> list_M = new List_m<T>();
        index = 0;
        Data = new T[index];
    }
    //添加
    public void add_(T m)
    {

        T[] M = new T[index];
        for (int i = 0; i < Data.Length; i++)
        {
            M[i] = Data[i];
        }
        index++;//
        Data = new T[index];
        for (int i = 0; i < Data.Length - 1; i++)
        {
            Data[i] = M[i];
        }
        Data[index - 1] = m;
    }

    //删除
    public void Clenar(int indx)
    {
        Debug.Log("删除");

        if (indx >= Data.Length)
        {
            return;
        }
        for (int i = indx; i < Data.Length - 1; i++)
        {
            Data[i] = Data[i + 1];
            Debug.Log(Data[i] + "mm" + i);
        }
        Debug.Log(index + "删除");

        index--;
    }
    //修改值
    public void Find_index(int index, T change)
    {
        Debug.Log("修改值");
        if (Data.Length - 1 < index)
        {
            return;
        }
        Data[index] = change;
    }
    //查找并返回
    public T Get_Tayp(int index)
    {
        Debug.Log("查找并返回");
        if (index >= Data.Length)
        {
            return default(T);
        }
        return Data[index];
    }
}
