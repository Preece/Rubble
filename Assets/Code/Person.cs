using UnityEngine;
using System.Collections;

public class Person : MonoBehaviour {

    [SerializeField]
    string name; 
    public string Name { get { return name; } }
    [SerializeField]
    string profession;
    public string Profession { get { return profession; } }
    [SerializeField]
    string specialization;
    public string Specialization { get { return specialization; } }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
