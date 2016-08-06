using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Building : MonoBehaviour {

    [SerializeField]
    string name; 
    public string Name { get { return name; } }
    [SerializeField]
	float efficiency = 1.0f;
	float currentCycle = 0.0f; 

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

	[SerializeField]
	List<Recipe> recipes;

	Recipe currentRecipe;


	// Use this for initialization
	void Start () {
        jobs = GetComponentsInChildren<Job>();
        GameManager.RegisterBuilding(this);

		currentRecipe = recipes[0];
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
        Debug.Log("Producing: " + currentRecipe); 
    }

    public void NextCycle()
    {
		if (currentRecipe != null) {
			currentCycle++;

			if (currentCycle > (currentRecipe.GetCyclesToProduce() * efficiency))
			{
				currentCycle -= (currentRecipe.GetCyclesToProduce() * efficiency);
				Produce(); 
			}
		}
        
    }

	public List<Building> GetUpgradePossiblities() 
	{
		return upgradePossibilities;
	}

	public List<Recipe> GetRecipes() 
	{
		return recipes;
	}

    public void ClickedOn()
    {
        Debug.Log("clicked on" + name);
        UIManager.DisplayBuildingMenu(this); 
    }

    public void UpgradeBuliding(Building upgradeBuilding)
    {
        upgradingTo = upgradeBuilding; 
    }
}
