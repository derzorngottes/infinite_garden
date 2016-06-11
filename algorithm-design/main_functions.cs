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
