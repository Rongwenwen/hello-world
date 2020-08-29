using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class File_Test : MonoBehaviour
{
    #region MyRegion
    /*
   string path_;
   string[] vs_;
   void Start()
   {
       path_ = Application.streamingAssetsPath + "/Test.txt";
       StartCoroutine("Loading_Txt");
   }


   IEnumerator Loading_Txt()
   {
       WWW wWW_ = new WWW(path_);
       if (!wWW_.isDone)
       {
           yield return wWW_;
           string txt_ = wWW_.text;
           Get_Txt(txt_);
           Debug.Log("===");
       }
       yield return null;
   }


   void Get_Txt(string txt)
   {
       vs_ = txt.Split('n');//根据换行符“划分”出多个“行文本”
   }
   private void Update()
   {
       if (Input.GetMouseButtonDown(0))

       {
           Debug.Log("---" + vs_[0]);

       }
   }*/

    #endregion

    [SerializeField]
    Button button_;
    public static Texture tex;
    public GameObject panel;
    private void Start()
    {
        button_.onClick.AddListener(delegate { StartCoroutine("Test_Fun"); });
    }
    IEnumerator Test_Fun()
    {
        yield return new WaitForEndOfFrame();
        tex= ScreenCapture.CaptureScreenshotAsTexture();
        panel.SetActive(true);
    }

}
