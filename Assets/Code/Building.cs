using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Building : MonoBehaviour {

    [SerializeField]
    string name; 
    public string Name { get { return name; } }
    [SerializeField]
    int cyclesToProduce = 1;
    int currentCycle = 0; 
    Job[] jobs;

    //The lists are so we can view and set values in the inspector
    [SerializeField]
    List<ResourceMax> _inputStock;
    //The dictionary is what we use in game. Having both reference the same resource instance should keep it all linked. 
    Dictionary<string, ResourceMax> inputStock;
    [SerializeField]
    List<ResourceMax> _outputStock;
    Dictionary<string, ResourceMax> outputStock; 
    [SerializeField]
    List<Resource> productionInput;
    [SerializeField]
    List<Resource> productionOutput;
    [SerializeField]
    List<Resource> creationCost; 
    [SerializeField]
    List<Building> upgradePossibilities;
    Dictionary<string, int> upgradeStock;
    Building upgradingTo; 


	// Use this for initialization
	void Start () {
        jobs = GetComponentsInChildren<Job>();
        GameManager.RegisterBuilding(this);
	}

    internal void UpdateEfficiency()
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update () {
	
	}

    void Produce()
    {
        Debug.Log("producing"); 
    }

    public void NextCycle()
    {
        currentCycle++;
        if (currentCycle > cyclesToProduce)
        {
            currentCycle -= cyclesToProduce;
            Produce(); 
        }
    }
    public void ClickedOn()
    {
        Debug.Log("clicked on" + name);
        UIManager.DisplayUpgradePossiblities(this, upgradePossibilities); 
    }
    public void UpgradeBuliding(Building upgradeBuilding)
    {
        upgradingTo = upgradeBuilding; 
    }
}
