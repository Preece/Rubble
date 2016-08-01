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
    UpgradeButton buttonPrefab; 

    void Awake()
    {
        t = this; 
    }

    void Start()
    {
        Deselect(); 
    }

	public static void DisplayUpgradePossiblities(Building currentBuilding, List<Building> buildings)
    {
        t.backgroundPanel.enabled = true;
        t.scrollable.enabled = true; 
        for(int i = 0; i < buildings.Count; i++)
        {
            UpgradeButton button = Instantiate(t.buttonPrefab);
            button.transform.SetParent(t.scrollable.transform);
            button.Created(currentBuilding, buildings[i]); 
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
