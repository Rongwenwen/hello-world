using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Webcam_Test : MonoBehaviour
{

    private bool camAvailable;

    private WebCamTexture cameraTexture;


    public RawImage background;
    public AspectRatioFitter fit;
    public bool frontFacing;


    void Start()
    {

        WebCamDevice[] devices = WebCamTexture.devices;



        if (devices.Length == 0)
            return;


        for (int i = 0; i < devices.Length; i++)
        {
            var curr = devices[i];


            if (curr.isFrontFacing == frontFacing)
            {
                curr = WebCamTexture.devices[0];
                cameraTexture = new WebCamTexture(curr.name, Screen.width, Screen.height, 15);
                break;
            }
        }


        if (cameraTexture == null)
            return;


        cameraTexture.Play(); // Start the camera  
        background.texture = cameraTexture; // Set the texture  


        camAvailable = true; // Set the camAvailable for future purposes.  
    }


    // Update is called once per frame  
    void Update()
    {
        if (!camAvailable)
            return;


        float ratio = (float)cameraTexture.width / (float)cameraTexture.height;
        fit.aspectRatio = ratio; // Set the aspect ratio  


        float scaleY = cameraTexture.videoVerticallyMirrored ? -1f : 1f; // Find if the camera is mirrored or not  
        background.rectTransform.localScale = new Vector3(1f, scaleY, 1f); // Swap the mirrored camera  


        int orient = -cameraTexture.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);



    }

    //这下面的是我跳转到AR场景当中的，需要把上个场景中的webcamTexture关闭。

    //没有这一需求的小伙伴门可以忽略

    private void OnDestroy()
    {
        //background.texture = null;
        cameraTexture.Stop();
        cameraTexture = null;
    }
}