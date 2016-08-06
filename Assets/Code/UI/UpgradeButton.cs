using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class UpgradeButton : MonoBehaviour {

    [SerializeField]
    Text text;
    [SerializeField]
    Image background; 
    Building currentBuilding;
    Building upgradeBuilding;
   
    public void Created(Building current, Building upgrade)
    {
        currentBuilding = current;
        upgradeBuilding = upgrade;
        text.text = upgradeBuilding.Name;
    }
    public void Click()
    {

    }

}
