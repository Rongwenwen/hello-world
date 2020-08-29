using UnityEngine;

using System.Collections;

using System.IO;

using System.Text;

using System;
using UnityEngine.UI;

public class writeTxT : MonoBehaviour
{

    void Start()
    {

        string name = "Account";

        String path = Application.persistentDataPath;

        //写入流

        writeFile(path, name);

        //追加字符

        //addFile(path, name);

        ////逐个加入

        //addOneByOne(path)

    }



    //写入流
    FileStream fs;
    string Pathm;
    void writeFile(string path, string fileName)
    {

        fs = new FileStream(path + "/" + fileName, FileMode.Create);   //打开一个写入流
        Pathm = path + "/" + fileName;
        Debug.Log(path + "/" + fileName + "   ]]]]");
        string str = "账号:1533725879,密码:123456";

        byte[] bytes = Encoding.UTF8.GetBytes(str);

        fs.Write(bytes, 0, bytes.Length);

        fs.Flush();     //流会缓冲，此行代码指示流不要缓冲数据，立即写入到文件。

        fs.Close();     //关闭流并释放所有资源，同时将缓冲区的没有写入的数据，写入然后再关闭。

        fs.Dispose();   //释放流所占用的资源，Dispose()会调用Close(),Close()会调用Flush();    也会写入缓冲区内的数据。



    }



    //追加字符

    void addFile(string path, string fileName)
    {

        //写入流，追加文本

        FileStream FileStreamfs = new FileStream(path + "//" + fileName, FileMode.Append, FileAccess.Write);  //追加流，权限设置为可写

        byte[] bytes = Encoding.UTF8.GetBytes("追加字符");

        fs.Write(bytes, 0, bytes.Length);

        fs.Flush();

    }

    //写入流，逐个字符逐个字符吸入

    void addOneByOne(string path)
    {

        //写入流，逐个字符逐个字符吸入

        FileStream FileStreamfs = new FileStream(path + "//" + "newFile.txt", FileMode.CreateNew, FileAccess.Write);    // newFile.txt并写入

        byte[] bytes = Encoding.UTF8.GetBytes("逐个字符逐个字符吸入");

        foreach (byte b in bytes)

        {

            fs.WriteByte(b);        //逐个字节逐个字节追加入文本

        }

        fs.Flush();

    }

    string wem;
    void Read_Txt(string path)
    {
        if (File.Exists(path))
        {
            //FileStream Text = new FileStream("", FileMode.Open);
            ////byte[] bytes = Encoding.UTF8.GetBytes()
            ////Text.Read();
            StreamReader read = new StreamReader(path);
            wem= read.ReadToEnd();
            Debug.Log("读取pp" + wem);
            read.Close();
        }
        Debug.Log("不存在pppp");
    }
    [SerializeField]
    Text text;
    private void OnGUI()
    {
        if (GUI.Button(new Rect(20, 20, 100, 20), "开始"))
        {
            Read_Txt(Pathm);
            text.text = wem;
        }
       
    }
}