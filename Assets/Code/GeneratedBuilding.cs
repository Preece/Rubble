using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class GeneratedBuilding  {
    public Building buildling;
    public int weight = 10;
    public int minimum = 0; 
}
public struct BuildingWeightProb
{
    public int maxWeight;
    public Building building; 
    public BuildingWeightProb(int _weight, Building _building)
    {
        maxWeight = _weight;
        building = _building; 
    }
}