using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;


public class ScreenShot : MonoBehaviour {

	// the URL (with endpoint) the pic will be sent to
	public string screenShotURL= "https://api.imgur.com/3/image";


	[DllImport("__Internal")]
	private static extern void SendImgurData(string data);


	IEnumerator UploadPic(string screenShotURL) {
		// We should only read the screen after all rendering is complete
		yield return new WaitForEndOfFrame();

		// Create a texture the size of the screen, RGB24 format
		int width = Screen.width;
		int height = Screen.height;
		var tex = new Texture2D( width, height, TextureFormat.RGB24, false );

		// Read screen contents into the texture
		tex.ReadPixels( new Rect(0, 0, width, height), 0, 0 );
		tex.Apply();

		// Encode texture into PNG
		byte[] bytes = tex.EncodeToPNG();
		Destroy( tex );

		// Create a Web Form with info to pass with POST request
		//		WWWForm form = new WWWForm();

		// Add a custom header to request for API authentication
		Dictionary<string, string> headers = new Dictionary<string, string>();
		headers["Authorization"] = "Client-ID d50b1f777cbdb38";

		// Upload to URL specified
		WWW w = new WWW(screenShotURL, bytes, headers);
		yield return w;
		if (!string.IsNullOrEmpty(w.error)) {
			print(w.text);
		}
		else {
			SendImgurData (w.text);
			print("img uploaded =)");
		}
	}

	// Initialization for UploadPic
	void UploadPicture(string screenShotURL) {
		StartCoroutine(UploadPic(screenShotURL));
	}

	// Creates menu on screen for image capture
	void OnGUI() {
		GUILayout.BeginArea(new Rect(0,0, 100, 100)); 			// creates menu body
		if(GUILayout.Button("Take picture")) {					// creates button "Take Picture" and if clicked, calls UploadPicture function
			UploadPicture(screenShotURL);
		}
		GUILayout.EndArea();									// removes image capture menu after picture is sent
	}
}
