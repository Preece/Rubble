using UnityEngine;
using System.Collections;

public class Job : MonoBehaviour {

    [SerializeField]
    bool isRequired = false;
    [SerializeField]
    float maxEfficiency = 10f;
    [SerializeField]
    string requiredRole = "labor";
    

    Building building;
    Person worker; 

    public void AddWorker(Person person)
    {
        //what do we want to happen if the worker isn't qualified? 
        worker = person; 
    }
    public void RemoveWorker()
    {
        //anything else that needs to happen when they leave
        worker = null; 
    }
    public void InitializeJob(Building _building)
    {
        //invoked by teh building it's attached to at the start of game, or when building is generated. 
        building = _building; 
    }
    public void updateEfficiency()
    {
        building.UpdateEfficiency(); 
    }
    public float getEfficiency()
    {
        //placeholder logic. Need conversation on how each role works. 
        if(worker != null)
        {
            return maxEfficiency; 
        }
        else
        {
            return 0; 
        }
    }



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
