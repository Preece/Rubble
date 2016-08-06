using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Recipe : MonoBehaviour {

	[SerializeField]
	string name; 
	public string Name { get { return name; } }

	[SerializeField]
	List<Resource> input;
    public List<Resource> Input { get { return input; } }

	[SerializeField]
	List<Resource> output;
    public List<Resource> Output { get { return output; } }

	[SerializeField]
	float secondsToProduce = 1.0f;

	public float GetCyclesToProduce() {
		return secondsToProduce * 5;
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
