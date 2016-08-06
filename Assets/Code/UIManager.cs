using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic; 

public class UIManager : MonoBehaviour {

    static UIManager t; 
    [SerializeField]
    Image backgroundPanel;
    [SerializeField]
    Image scrollable;
    [SerializeField]
    UpgradeButton upgradeButtonPrefab;
	[SerializeField]
	RecipeButton recipeButtonPrefab;

    void Awake()
    {
        t = this; 
    }

    void Start()
    {
        Deselect(); 
    }

	public static void DisplayBuildingMenu(Building currentBuilding) 
	{
		t.backgroundPanel.enabled = true;
		t.scrollable.enabled = true; 

		UIManager.DisplayUpgradePossiblities (currentBuilding);	
		UIManager.DisplayRecipes (currentBuilding);	
	}

	public static void DisplayUpgradePossiblities(Building currentBuilding)
    {
		List<Building> buildings = currentBuilding.GetUpgradePossiblities ();

        for(int i = 0; i < buildings.Count; i++)
        {
			UpgradeButton button = Instantiate(t.upgradeButtonPrefab);
            button.transform.SetParent(t.scrollable.transform);
            button.Created(currentBuilding, buildings[i]); 
        }
    }

	public static void DisplayRecipes(Building currentBuilding)
	{
		List<Recipe> recipes = currentBuilding.GetRecipes();

		for(int i = 0; i < recipes.Count; i++)
		{
			RecipeButton button = Instantiate(t.recipeButtonPrefab);
			button.transform.SetParent(t.scrollable.transform);
			button.Created(currentBuilding, recipes[i]); 
		}
	}

    public static void Deselect()
    {
        t.backgroundPanel.enabled = false;
        t.scrollable.enabled = false; 
        List<GameObject> children = new List<GameObject>(); 
        foreach(Transform child in t.scrollable.transform)
        {
            children.Add(child.gameObject); 
        }
        children.ForEach(child => Destroy(child)); 
    }
}
