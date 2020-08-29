using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.IO;
using UnityEngine.UI;


public class XmlHelp : MonoBehaviour
{

    // Use this for initialization

    public static string XmlPath = "";

    [SerializeField]
    Text text_;


    void Start()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            XmlPath = Application.streamingAssetsPath + "/XML/" + "xmlText.xml";

        }
        if (Application.platform == RuntimePlatform.Android)
        {
            XmlPath = Application.persistentDataPath + "xmlText.xml";

        }
        Debug.Log(XmlPath + "当前平台路径");
        CreatXml(XmlPath);
        StartCoroutine(LoadXml(XmlPath, "Student", "1", text_));
    }

    // Update is called once per frame
    /// <summary>
    /// 创建Xml文本
    /// </summary>
    public static void CreatXml(string Path)
    {
        if (!File.Exists(Path))
        {
           XmlDocument xmlData = new XmlDocument(); 
            
            XmlElement RootxmlElement = xmlData.CreateElement("Student");
            XmlElement OneNodexmlElement = xmlData.CreateElement("rongwewen");
            OneNodexmlElement.SetAttribute("id", "1");
            OneNodexmlElement.SetAttribute("Age", "22");
            XmlElement qqNodexmlElement = xmlData.CreateElement("qq");
            qqNodexmlElement.InnerText = "123456";
            XmlElement weixixmlElement = xmlData.CreateElement("weixi");
            weixixmlElement.InnerText = "56789";
            XmlElement namexmlElement = xmlData.CreateElement("Name");
            namexmlElement.InnerText = "稳稳";


            //建立关系
            OneNodexmlElement.AppendChild(qqNodexmlElement);
            OneNodexmlElement.AppendChild(weixixmlElement);
            OneNodexmlElement.AppendChild(namexmlElement);
            RootxmlElement.AppendChild(OneNodexmlElement);
            xmlData.AppendChild(RootxmlElement);
            xmlData.Save(Path);
        }
    }



    /// <summary>
    /// 加载文件中的值
    /// </summary>
    /// <param name="Path">文件路径</param>
    /// <param name="Root">根节点</param>
    /// <param name="id">子节点对应id值</param>
    public static IEnumerator LoadXml(string Path, string Root, string id, Text text)
    {
        while (!File.Exists(Path))
        {
            yield return new WaitForSeconds(0.5f);
        }
        if (File.Exists(Path))
        {
            XmlDocument xmlData = new XmlDocument();
            xmlData.Load(Path);
            XmlNodeList xmlNodeList = xmlData.SelectSingleNode(Root).ChildNodes;
            foreach (XmlElement item in xmlNodeList)
            {
                //根节点的子节点
                if (item.GetAttribute("id") == id)
                {
                    XmlNode xmlNode = item.SelectSingleNode("qq");
                    Debug.Log("name的值" + xmlNode.InnerText+Application.dataPath);
                    text.text = xmlNode.InnerText;
                    break;
                }
            }
        }


    }
}
