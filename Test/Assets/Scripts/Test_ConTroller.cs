using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_ConTroller : MonoBehaviour
{
    [SerializeField]
    GameObject game_Cube;
    //实现鼠标拖拽物体
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //先获取目标物体在屏幕坐标的Z轴
            var p = Camera.main.WorldToScreenPoint(game_Cube.transform.position);
            //获取鼠标位置
            var mos_Pos = Input.mousePosition;
            //改变鼠标位置的Z轴(主要的一步)
            mos_Pos.z = p.z;
            //然后再把改变后的鼠标位置转换到世界坐标
            var mouse_Pos = Camera.main.ScreenToWorldPoint(mos_Pos);
            game_Cube.transform.position = Vector3.MoveTowards(game_Cube.transform.position, mouse_Pos, 15 * Time.deltaTime);
            Debug.Log("tagert：" + mouse_Pos);
        }
    }
}
