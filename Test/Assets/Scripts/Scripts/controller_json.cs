using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System.Text;
using UnityEngine.UI;

public class controller_json : MonoBehaviour
{

    // Use this for initialization

    string text_name;
    double[] pos;
    Cube_Data cube_Data;
    // Update is called once per frame
    public Text text;

    public Text text_Info;

    string ad_path_tagert;
    private void Start()
    {
        json_Path = Application.persistentDataPath + "/test.txt";
        
        if (!System.IO.File.Exists(json_Path))
        {
            //System.IO.File.Create(filePath);
            Debug.Log("并不存在");
            System.IO.File.Create(json_Path).Dispose();
        }
        File.Create(json_Path);
        cube_Data = new Cube_Data();
        cube_Data.pos = new double[3];
        for (int i = 0; i < cube_Data.pos.Length; i++)
        {
            if (i == 0)
            {
                cube_Data.pos[i] = this.transform.position.x;
            }
            if (i == 1)
            {
                cube_Data.pos[i] = this.transform.position.y;
            }
            if (i == 2)
            {
                cube_Data.pos[i] = this.transform.position.z;
            }
        }
        cube_Data.name = this.name;
        //Creat_Json();
        Invoke("Creat_Json", 2f);
        //Init();
        //StartCoroutine("Read_Data_Www");

       
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DataToJson();

        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            JsonToObject();
        }
        //if(Input.GetMouseButtonDown(0))
        //{
        //    Creat_Json();
        //}

        //if (Input.GetMouseButtonDown(0))
        //{
        //    ReadData();
        //}
    }
    string json_Data;
    public void DataToJson()
    {
        json_Data = JsonMapper.ToJson(cube_Data);
        Debug.Log("//" + json_Data);
    }
    public void JsonToObject()
    {
        Cube_Data cube = JsonMapper.ToObject<Cube_Data>(json_Data);
        for (int i = 0; i < cube.pos.Length; i++)
        {
            Debug.Log("反序列化//" + cube.pos[i]);
        }
    }
    string json_Path;
    public void Creat_Json()
    {
        //第一种方式创建json文本
        JsonData json_Data_Root = new JsonData();
        JsonData jsonData = new JsonData();
        jsonData["name"] = "稳稳";
        jsonData["age"] = "20";
        jsonData["location"] = "上海宝山";
        JsonData jsonData2 = new JsonData();

        jsonData2["name"] = "稳2";
        jsonData2["age"] = "23";
        jsonData2["location"] = "上海宝山2";

        JsonData jsonData_arry = new JsonData();
        jsonData_arry.SetJsonType(JsonType.Array);
        jsonData_arry.Add(jsonData);
        jsonData_arry.Add(jsonData2);

        json_Data_Root["jsonroot"] = jsonData_arry;

        Creat_File(json_Path, json_Data_Root.ToJson());

    }



    void Creat_File(string FlieNames, string json_info)
    {
        Debug.Log(json_info + "//");

        if (File.Exists(FlieNames))
        {


            File.WriteAllText(FlieNames, json_info, Encoding.ASCII);
            //streamWriter.Write(json_info);

            //streamWriter.Close();
            //Debug.Log("////");
            //FileStream fileStream = File.Create(FlieNames);

            //byte[] info = UTF8Encoding.UTF8.GetBytes(json_info);
            //fileStream.Write(info, 0, info.Length);
            //fileStream.Close();
            //File.CreateText(FlieNames);

            //File.WriteAllText(FlieNames, json_info, Encoding.UTF8);

        }


    }


    public class Cube_Data
    {
        public double[] pos;
        public string name;

    }

    //读取数据
    public void ReadData()
    {
        if (!File.Exists(json_Path)) return;
        string FileName = json_Path;
        StreamReader json = File.OpenText(FileName);

        string input = json.ReadToEnd();

        Dictionary<string, List<Dictionary<string, object>>> jsonObject = JsonMapper.ToObject<Dictionary<string, List<Dictionary<string, object>>>>(input);
        Debug.Log(jsonObject["jsonroot"][0]["name"]);
        text.text = jsonObject["jsonroot"][0]["name"].ToString() + "llll";


    }

    public IEnumerator Read_Data_Www()
    {
        if (!File.Exists(json_Path)) yield break;
        WWW wWW = new WWW(json_Path);
        yield return wWW;
        string jsom = wWW.text;
        Debug.Log(jsom);
        Dictionary<string, List<Dictionary<string, object>>> jsonObject = JsonMapper.ToObject<Dictionary<string, List<Dictionary<string, object>>>>(jsom);
        Debug.Log(jsonObject["jsonroot"][0]["name"]);
        text.text = jsonObject["jsonroot"][0]["age"].ToString() + "2222";


    }


    string ad_Path;
    void Init()
    {
        if (Application.platform == RuntimePlatform.Android)
        {

            //安卓路径
            text.text = "安卓路径" + ad_Path;

            ad_Path = Application.persistentDataPath + "/test.txt";
           
            File.Copy(json_Path, ad_Path,true);
            

        }
      
    }

    public void Get_Data_Json()
    {
        text_Info.text = "未进入";
        text.text = "安卓路径" + ad_Path;
        if (!File.Exists(json_Path)) return;
        text_Info.text = "进入";
        string FileName = json_Path;
        StreamReader json = File.OpenText(FileName);

        string input = json.ReadToEnd();

        Dictionary<string, List<Dictionary<string, object>>> jsonObject = JsonMapper.ToObject<Dictionary<string, List<Dictionary<string, object>>>>(input);
        Debug.Log(jsonObject["jsonroot"][0]["name"]);
        text_Info.text = jsonObject["jsonroot"][0]["name"].ToString() + "llll";

    }

}
