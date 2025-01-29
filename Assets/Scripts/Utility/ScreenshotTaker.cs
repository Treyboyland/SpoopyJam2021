using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ScreenshotTaker : MonoBehaviour
{
    public void TakeScreenshot()
    {
        string directory = Application.dataPath + "/../Logs";
        if (Directory.Exists(directory))
        {
            string fileName = "Screenshot-" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss-fff") + ".png";
            ScreenCapture.CaptureScreenshot(directory + "/" + fileName);
        }
    }
}
