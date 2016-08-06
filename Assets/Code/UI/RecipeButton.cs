using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class RecipeButton : MonoBehaviour {

	[SerializeField]
	Text text;
	[SerializeField]
	Image background; 
	Building currentBuilding;
	Recipe currentRecipe;

	public void Created(Building selectedBuilding, Recipe recipe)
	{
		currentBuilding = selectedBuilding;
		currentRecipe = recipe;
		text.text = recipe.Name;
	}

	public void Click()
	{

	}

}
