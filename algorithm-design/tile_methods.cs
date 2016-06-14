using UnityEngine;
using System.Collections;
using System;

public class Tile : MonoBehavior {

  public bool isEmpty;
  public bool fertilized;
  public float lightLevel;
  public float elevation;
  public int x;
  public int y;
  public int z;

  // Methods:
  // AddPlant(){}
  // RemovePlant(){}

  // Properties:
  // isEmpty - boolean
  // fertilized - boolean
  // lightLevel - the amount of light coming to Tile (based on elevation)
  // elevation - elevation at time of map creation
  // int x, y, z - coordinates of this Tile

  public bool isEmpty = true;
  public bool fertilized = false; // if not fertilized, rate of growth is halved

  public float elevation = Map.getElevation(Tile); // function not yet written for Map
  public float lightLevel = elevation * elevationModifier // elevationModifier to be written when Map elevation levels are determined

  public Object AddPlant(newPlant) {
    // Should take plant object with genome either from user input or pollination
    // and add it to the tile
    private Vector3 plantPosition = new Vector3(this.x, this.y, this.z);
    GameObject plantToAdd = Instantiate (newPlant) as GameObject;

    plantToAdd.transform.position = plantPosition;
  }

  public void RemovePlant() {
    // Empty the tile of any plant object
  }

}
