﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

	private Text t;

	// Use this for initialization
	void Start () {
		t = GetComponent <Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		t.text = "SCORE: " + GlobalVars.points;
	}
}
