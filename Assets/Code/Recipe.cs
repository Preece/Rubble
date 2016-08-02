using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Recipe : MonoBehaviour {

	[SerializeField]
	List<Resource> input;

	[SerializeField]
	List<Resource> output;

	public float cyclesToProduce = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
