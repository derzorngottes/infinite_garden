using UnityEngine;
using System.Collections;
using System;

public class AllPlants : MonoBehavior {

  public Object PollinatedSeedling(Tile) {
    // Each Tile has a queue of plants ready to pollinate no greater than 10
    object parent0 = Tile.getPollinators() //returns random pollinator
    object parent1 = Tile.getPollinators() //ditto - should we pass in prev pollinator or can plant pollinate itself?

    Plant newPlant = new Plant();

    // Take each parent genome and randomly assign genes from a parent
    for (gene in genome) {
      int parent = randomParent();
      if (parent == 0) {
        // newPlant.genome.[this gene] = parent0.genome.[thisgene];
        // assign gene from parent0
      } else {
        // newPlant.genome.[this gene] = parent0.genome.[thisgene];
        //assign gene from parent1
      }
    }

  }

  public int randomParent() {
    Random rand = new Random(); //should this be at top of Plant
    return rand.Next(0, 2);
  }

}
