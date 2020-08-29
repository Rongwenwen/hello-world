using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class Swpae : MonoBehaviour {


    [SerializeField]
    VideoPlayer VideoPlayer;//视频控制器
    float xStartPos;//第一次按下的位置x
    float xNowPos;//每帧的位置x
    float xDistance;//x轴方向上移动的距离
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
        if(Input.touchCount>0)
        {

            if(Input.GetTouch(0).phase==TouchPhase.Began)
            {
                xStartPos = Input.mousePosition.x;
            }

            xNowPos = Input.mousePosition.x;
            xDistance = Mathf.Abs(xNowPos - xStartPos);
          if(Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                if((xNowPos - xStartPos)>0)
                {
                    VideoPlayer.time = VideoPlayer.time + (xDistance / Screen.width) * VideoPlayer.clip.length;
                    if (VideoPlayer.time>= VideoPlayer.clip.length)
                    {
                        VideoPlayer.time = VideoPlayer.clip.length;

                        VideoPlayer.Stop();
                    }
                    VideoPlayer.Play();
                }
                if ((xNowPos - xStartPos) < 0)
                {

                    VideoPlayer.time = VideoPlayer.time -(xDistance / Screen.width) * VideoPlayer.clip.length;
                    if (VideoPlayer.time <=0)
                    {
                        VideoPlayer.time = 0;

                        VideoPlayer.Play();
                    }
                    VideoPlayer.Play();
                }

            }
        }
	}
}
