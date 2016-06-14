using UnityEngine;
using System.Collections;

// Has to be attached to a GameObject (empty) called Map Generator

// Other objects:

// Plane (GameObject => 3D Object => Plane)
// Create new Material in Material subfolder, call it 'Map Mat'
// Set its shader to 'Unlit/Texture'
// Attach Map Mat to the Plane by dragging to Plane's Materials
// Now drag the Plane from the Hierarchy to the Texture Render slot on the Map Generator
// pane on the right hand side.

// Mesh (GameObject => Empty, call it 'Mesh')
// Then with Mesh highlighted in Hierarchy, Component => Mesh => Mesh Filter
// And Component => Mesh => Mesh Renderer
// Then create a new Material in the Materials folder, call it 'Mesh Mat'
// Set its smoothness to 0
// Drag it into the Materials of the Mesh
// Then drag the Mesh from the Hierarchy to the Mesh Filter and Mesh Renderer of the Map display
// tab of the Map Generator (in the right pane)

public class MapGenerator : MonoBehaviour {

	public enum DrawMode { NoiseMap, ColourMap, Mesh, FalloffMap } ;

	public DrawMode drawMode;

	public int mapWidth;
	public int mapHeight;
	public float noiseScale;

	public int octaves;
	[Range (0, 1)]
	public float persistance;
	public float lacunarity;

	public int seed;
	public Vector2 offset;

	public bool useFalloff;

	public float meshHeightMultiplier;
	public AnimationCurve meshHeightCurve;

	public bool autoUpdate;

	public TerrainType[] regions;

	float[,] falloffMap;

	void Awake() {
		falloffMap = FalloffGenerator.GenerateFalloffMap (241);
	}

	public void GenerateMap ()
	{
		float[,] noiseMap = Noise.GenerateNoiseMap (mapWidth, mapHeight, seed, noiseScale, octaves, persistance, lacunarity, offset);

		Color[] colourMap = new Color[mapWidth * mapHeight];
		for (int y = 0; y < mapHeight; y++) {
			for (int x = 0; x < mapWidth; x++) {
				if(useFalloff) {
					noiseMap [x, y] = Mathf.Clamp01(noiseMap [x, y] - falloffMap [x, y]);
				}
				float currentHeight = noiseMap [x, y];
				for (int i = 0; i < regions.Length; i++) {
					if (currentHeight <= regions [i].height) {
						colourMap [y * mapWidth + x] = regions [i].colour;
						break;
					}
				}
			}
		}

		MapDisplay display = FindObjectOfType<MapDisplay> ();
		if (drawMode == DrawMode.NoiseMap) {
			display.DrawTexture (TextureGenerator.TextureFromHeightMap (noiseMap));
		} else if (drawMode == DrawMode.ColourMap) {
			display.DrawTexture (TextureGenerator.TextureFromColourMap (colourMap, mapWidth, mapHeight));
		} else if (drawMode == DrawMode.Mesh) {
			display.DrawMesh (MeshGenerator.GenerateTerrainMesh (noiseMap, meshHeightMultiplier, meshHeightCurve), TextureGenerator.TextureFromColourMap (colourMap, mapWidth, mapHeight));
		} else if(drawMode == DrawMode.FalloffMap) {
			display.DrawTexture (TextureGenerator.TextureFromHeightMap (FalloffGenerator.GenerateFalloffMap (241)));
		}
	}

	void OnValidate ()
	{
		if (mapWidth < 1) {
			mapWidth = 1;
		}
		if (mapHeight < 1) {
			mapHeight = 1;
		}
		if (lacunarity < 1) {
			lacunarity = 1;
		}
		if (octaves < 0) {
			octaves = 0;
		}

		falloffMap = FalloffGenerator.GenerateFalloffMap (241);
	}
}

[System.Serializable]
public struct TerrainType
{
	public string name;
	public float height;
	public Color colour;
}
