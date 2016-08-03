﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Recipe : MonoBehaviour {

	[SerializeField]
	List<Resource> input;

	[SerializeField]
	List<Resource> output;

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
