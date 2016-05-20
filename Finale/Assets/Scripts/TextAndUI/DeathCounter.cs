using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DeathCounter : MonoBehaviour {
	
	private Text t;
	
	// Use this for initialization
	void Start () {
		t = GetComponent <Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GlobalVars.ended) {
			t.text = "";
		} else {
			t.text = "DEATHS: " + GlobalVars.deathCount;
		}
	}
}
