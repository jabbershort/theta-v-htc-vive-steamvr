using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WebCamViewer : MonoBehaviour
{
    string camName;
	public const string RICOH_DRIVER_NAME = "Theta UVC";
	// public const string RICOH_DRIVER_NAME = "RICOH THETA Z1";
    WebCamTexture mycam;
    RawImage img;
    void Start()
    {
		WebCamDevice[] devices = WebCamTexture.devices;
		// Debug.Log("Number of web cams connected: " + devices.Length);
		for (int i = 0; i < devices.Length; i++)
		{
			// Debug.Log(i + " " + devices[i].name);
			if (devices[i].name == RICOH_DRIVER_NAME)
			{
				camName = devices[i].name;
			}
		}

		Debug.Log("I am using the webcam named " + camName);

		if (camName != RICOH_DRIVER_NAME)
		{
			Debug.Log("ERROR: " + RICOH_DRIVER_NAME +
				" not found. Install Ricoh UVC driver 1.0.1 or higher. Make sure your camera is in live streaming mode");
		}

		mycam = new WebCamTexture();
		mycam.deviceName = camName;

		mycam.Play();
		Debug.Log(mycam.isReadable);
		Debug.Log(mycam.dimension);
		Debug.Log(mycam.updateCount);
    }

    // Update is called once per frame
    void Update()
    {
		Debug.Log("testing");
		if(!mycam.isPlaying)
		{
			mycam.Play();
		}
        img = transform.GetComponent<RawImage>();
		img.texture = mycam;
		img.material.mainTexture = mycam;
    }
}
