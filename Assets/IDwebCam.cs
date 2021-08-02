using System.Collections;
 using System.Collections.Generic;
 using UnityEngine.UI;
 using UnityEngine;
 
 public class IDwebCam : MonoBehaviour {
 
     public RawImage rawimage;
     WebCamTexture webCamTexture;
 
     public Text webCamDisplayText;
 
     void Start ()
     {
 
 
         WebCamDevice[] cam_devices = WebCamTexture.devices;
         // for debugging purposes, prints available devices to the console
         for (int i = 0; i < cam_devices.Length; i++) 
         {
             print ("Webcam available: " + cam_devices [i].name);
         }
		GoWebCam01();
     }
 
 
     //CAMERA 01 SELECT
     public void GoWebCam01()
     {
         WebCamDevice[] cam_devices = WebCamTexture.devices;
         // for debugging purposes, prints available devices to the console
         for (int i = 0; i < cam_devices.Length; i++) 
         {
             print ("Webcam available: " + cam_devices [i].name);
         }
 
         webCamTexture = new WebCamTexture(cam_devices[0].name, 480, 640, 30);
         if(webCamTexture)
         {
            Color[] pixels = webCamTexture.GetPixels();
            print(pixels.Length);
         }

         rawimage.texture = webCamTexture;
         if(webCamTexture != null)
         {
             webCamTexture.Play();
             Debug.Log("Web Cam Connected : "+webCamTexture.deviceName + "\n");
         }    
         webCamDisplayText.text = "Camera Type: " + cam_devices [0].name.ToString();
     }
 }