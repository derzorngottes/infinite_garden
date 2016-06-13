using UnityEngine;
using System.Collections;
using System;

public class Plant : MonoBehavior {

  // Create a set of genes using binary int values (1 and 0)
  // Tie each gene to a an environmental interaction or to a
  // trait such as longevity
  // i.e.
  // { longevity, light needs, color, virility }
  //
  //   longevity = randomized weighted average lifespan
  //   light needs = inherited and prone to mutation. Effects longevity and height/color
  //   color = inherit color code from ground/nearby/parents, alpha for dark/pale
  //   virility = randomized weighted likelihood of reproducing with nearby plants
  //
  // Other genes?:
  //   texture = inherit texture from parent, prone to mutation
  //   height/width = inherit, affected by light, increases with age according to weighted growth factor
  //      * each plant should have maxheight and maxwidth
  //
  // Aside from genes, attach functions
  //   Degenerate() = plant is sick (too much light, etc), longevity and appearance affected
  //   Grow() = plant grows according to genetics, light, weighted by elevation (higher elev, start smaller)
  //   Pollinate() = creates copy of genome and passes into New Plant constructor
  //   Mutate()

  int[] abcd = new int[] { 0, 0, 0, 0 };
  int[] bacd = new int[] { 1, 1, 1, 1 };
  int[] cbad = new int[] { 1, 0, 1, 0 };
  int[] dbca = new int[] { 0, 1, 0, 1 };

  int[][] genome = new int[][] { abcd, bacd, cbad, dbca };

  public virtual int[][] FitnessFunction(Genome genome) {
    // placeholder
    return genome;

    // possible outcomes - plant has reached maxheight, must die?
    // plant has reached fastest grow conditions?
    // etc?
  }

  void Degenerate(int lightDifference) {
    // if lightDifference > this.lightTolerence
    // { this.alpha ++; this.growthRate = 0; this.longevityRate --; }
    //
    // else (if cause is something else) { same but different rate? }
  }

  void Grow() {
    // if this.Tile.lightLevel is within 0.3 of this.lightTolerence
    // if this.height != this.maxHeight
    // if this.width != this.maxWidth

    // this.height *= this.growthRate;
    // this.width *= this.growthRate;

    // if this.colorAlpha != this.idealAlpha, this.colorAlpha ++

    // random chance of this.Pollinate()
    // random chance of this.Mutate()
  }

  void Pollinate() {
    // Plant babyPlant = this;

    // return babyPlant;
  }

  void Die() {
    // this.Tile.isEmpty = true;
    // this.Tile.soil.fertilized = true;

    // remove from map
    // remove from any databases
  }
}
