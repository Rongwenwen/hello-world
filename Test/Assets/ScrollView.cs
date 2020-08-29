using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;

public class ScrollView : MonoBehaviour
{

    public int xOffset = 1;//x轴偏移
    public int yOffset = 0;//y轴偏移
    public float scale = 0.8f;//缩放倍数
    public float time = 0.5f;//偏移与缩放动画的播放时间

    private int left;//最左端的编号
    private int right;//最右端的编号
    public int itemAmount = 5;//展示的图片数
    public Vector3 middlePos;//最中间的位置

    public GameObject itemPrefab;
    private GameObject canvas;
    private GameObject[] sortArray;
    private List<GameObject> list = new List<GameObject>();

    private void InstantiateItem(Vector3 pos, float scale)
    {
        GameObject go = Instantiate(itemPrefab) as GameObject;
        go.transform.SetParent(canvas.transform);
        go.transform.localPosition = pos;
        go.transform.localScale *= scale;

        InsertToSortArray(go, go.transform.localScale.x);
        list.Add(go);
    }


    private void Start()
    {
        Init();
    }

    public void Init()
    {
        left = 0;
        right = itemAmount - 1;
        canvas = GameObject.Find("Canvas");
        sortArray = new GameObject[itemAmount];

        int oneSideAmount = (itemAmount - 1) / 2;

        for (int i = oneSideAmount; i >= 1; i--)
        {
            Vector3 pos = middlePos + new Vector3(i * xOffset, i * yOffset, 0) * -1;
            InstantiateItem(pos, Mathf.Pow(scale, i));
        }

        InstantiateItem(middlePos, 1);

        for (int i = 1; i <= oneSideAmount; i++)
        {
            Vector3 pos = middlePos + new Vector3(i * xOffset, i * yOffset, 0);
            InstantiateItem(pos, Mathf.Pow(scale, i));
        }

        Sort();
    }

    /// <summary>
    /// 根据缩放倍数计算深度
    /// </summary>
    /// <param name="scaleNum"></param>
    /// <returns></returns>
    private int CalculateDepth(float scaleNum)
    {
        float num = 0;
        int i = 0;
        while (true)
        {
            num = Mathf.Pow(scale, i);
            if (num != scaleNum) i++;
            else break;
        }
        return i;
    }

    /// <summary>
    /// 插入到排序数组中，数组序号越低，则越远离屏幕
    /// </summary>
    /// <param name="go"></param>
    /// <param name="localScaleX"></param>
    private void InsertToSortArray(GameObject go, float localScaleX)
    {
        int depth = CalculateDepth(localScaleX);
        depth = itemAmount / 2 - depth;

        if (depth == itemAmount / 2)
            sortArray[depth * 2] = go;
        else if (sortArray[depth] == null)
            sortArray[depth] = go;
        else
            sortArray[depth + itemAmount / 2] = go;
    }

    private void Sort()
    {
        for (int i = 0; i < itemAmount; i++)
        {
            sortArray[i].transform.SetSiblingIndex(i);
        }
        sortArray = new GameObject[itemAmount];
    }

    public void Move(int direction)
    {
        if (direction == -1)//向左滑动
        {
            int startIndex = left;
            int lastIndex = right;
            Vector3 lastPos = list[lastIndex].transform.position;

            InsertToSortArray(list[startIndex], list[startIndex].transform.localScale.x);

            for (int i = 0; i < itemAmount - 1; i++)
            {
                int index = (lastIndex - i + itemAmount) % itemAmount;
                int preIndex = (index - 1 + itemAmount) % itemAmount;
                list[index].transform.DOMove(list[preIndex].transform.position, time);
                list[index].transform.DOScale(list[preIndex].transform.localScale, time);

                InsertToSortArray(list[index], list[preIndex].transform.localScale.x);
            }

            list[startIndex].transform.DOMove(lastPos, time);

            left = (left + 1) % itemAmount;
            right = (right + 1) % itemAmount;
        }
        else if (direction == 1)//向右滑动
        {
            int startIndex = right;
            int lastIndex = left;
            Vector3 lastPos = list[lastIndex].transform.position;

            InsertToSortArray(list[startIndex], list[startIndex].transform.localScale.x);

            for (int i = 0; i < itemAmount - 1; i++)
            {
                int index = (lastIndex + i + itemAmount) % itemAmount;
                int preIndex = (index + 1 + itemAmount) % itemAmount;
                list[index].transform.DOMove(list[preIndex].transform.position, time);
                list[index].transform.DOScale(list[preIndex].transform.localScale, time);

                InsertToSortArray(list[index], list[preIndex].transform.localScale.x);
            }

            list[startIndex].transform.DOMove(lastPos, time);

            left = (left - 1 + itemAmount) % itemAmount;
            right = (right - 1 + itemAmount) % itemAmount;
        }

        Sort();
    }
}
