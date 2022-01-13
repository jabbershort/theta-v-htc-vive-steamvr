using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class webCamDetect : MonoBehaviour
{
	string camName;
	public const string RICOH_DRIVER_NAME = "Theta UVC";
	// public const string RICOH_DRIVER_NAME = "RICOH THETA Z1";
	// change to "RICOH THETA V FullHD" for lower resolution 
	// (and thus smaller data size)

	// Audio
	public const int THETA_V_AUDIO_NUMBER = 0;   
	AudioSource audioSource;
	WebCamTexture mycam;

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
		

		// Renderer rend = this.GetComponentInChildren<Renderer>();
		// rend.material.mainTexture = mycam;
		
		RawImage rawI = transform.GetComponent<RawImage>();
		rawI.texture = mycam;
		rawI.material.mainTexture = mycam;
		

		mycam.Play();
		Debug.Log(mycam.isReadable);
		Debug.Log(mycam.dimension);
		Debug.Log(mycam.updateCount);

		// audio
		// this section working with HTC Vive, but have not 
		// verified spatial audio. Maybe try STEAM AUDIO?
		// https://valvesoftware.github.io/steam-audio/downloads.html
		// It's good enough for telepresence demo right now, but
		// I would like to tune the spatial audio
		//

		// audioSource = GetComponent<AudioSource>();
		// string[] audioDevices = Microphone.devices;

		// for (int i = 0; i < audioDevices.Length; i++)
		// {
		// 	Debug.Log(i + " " + audioDevices[i]);
		// }
		// audioSource.clip = Microphone.Start(audioDevices[THETA_V_AUDIO_NUMBER], true, 10, 44100);
		// audioSource.loop = true;
		// while (!(Microphone.GetPosition(null) > 0 )) { }
		// audioSource.Play();
	}
	void Update()
	{
		Debug.Log("testing");
		if(!mycam.isPlaying)
		{
			mycam.Play();
		}
	}
}