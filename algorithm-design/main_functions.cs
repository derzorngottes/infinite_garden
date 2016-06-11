using UnityEngine;
using System.Collections;
using System;

public GameObject myPlants;
// Should generate random coordinates for each prepopulated plant
// (will need to be separate function)
private Vector3[] plantPositions = new Vector3 {
   new Vector3(x, y, z), // x, y, z are map coordinates
   new Vector2(x, y, z)  // etc.
};

// for each plant position, add plant (will need to bring in plants)
private void Awake() {
   foreach (Vector3 plantPos in plantPositions) {
     GameObject newPlant = Instantiate (myPlants) as GameObject;
     myPlants.transform.position = plantPos;
   }
}

// In-game camera docs:
// http://docs.unity3d.com/ScriptReference/WaitForEndOfFrame.html
// SO answer: http://stackoverflow.com/questions/24496438/can-i-take-a-photo-in-unity-using-the-devices-camera
// https://docs.unity3d.com/ScriptReference/Application.CaptureScreenshot.html
public class WebCamPhotoCamera : MonoBehavior {
  WebCamTexture webCamTexture;

  void Start() {
    webCamTexture = new WebCamTexture();
    renderer.material.mainTexture = webCamTexture;
    webCamTexture.Play();
  }

  void TakePhoto() {
    yield return new WaitForEndOfFrame();

    Texture2D photo = new Texture2D(webCamTexture.width, webCamTexture.height);
    photo.SetPixels(webCamTexture.GetPixels());
    photo.Apply();

    byte[] bytes = photo.EncodeToPNG();

    File.WriteAllBytes(path + "photo.png", bytes);
  }
}
