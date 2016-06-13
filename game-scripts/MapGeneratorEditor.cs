using UnityEngine;
using System.Collections;
using UnityEditor;

// Adds fields to auto-regen map on field changes, and regen on 'Generate' button click.
// Located at Assets/Editor/MapGeneratorEditor.cs

[CustomEditor (typeof (MapGenerator))]
public class MapGeneratorEditor : Editor {

	public override void OnInspectorGUI() {
		MapGenerator mapGen = (MapGenerator)target;

		if(DrawDefaultInspector ()){
			if(mapGen.autoUpdate) {
				mapGen.GenerateMap ();
			}
		}

		if(GUILayout.Button("Generate")) {
			mapGen.GenerateMap ();
		}
	}
}
