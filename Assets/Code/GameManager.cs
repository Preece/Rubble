using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class GameManager : MonoBehaviour {

    [SerializeField]
    float secondsPerCycle = 0.2f;
    float pointInCycle = 0;
    static GameManager t; 

    List<Building> buildings; 

    void Awake()
    {
        t = this;
        buildings = new List<Building>(); 
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            HandleClick(); 
        }
        PassTime(); 
	}

    void PassTime()
    {
        pointInCycle += Time.deltaTime; 
        if(pointInCycle >= secondsPerCycle)
        {
            pointInCycle -= secondsPerCycle; 
            for(int i = 0; i < buildings.Count; i++)
            {
                buildings[i].NextCycle();
            }
        }
    }

    public static void RegisterBuilding(Building building)
    {
        GameManager.t.buildings.Add(building); 
    }

    void HandleClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit _hit; 
        if(Physics.Raycast(ray, out _hit))
        {
            Building hitBuilding = _hit.collider.gameObject.GetComponent<Building>(); 
            if (hitBuilding != null)
            {
                hitBuilding.ClickedOn(); 
            } 
        }
        else
        {
            ClickedNothing(); 
        }
    }

    void ClickedNothing()
    {
        UIManager.Deselect(); 
    }
}
