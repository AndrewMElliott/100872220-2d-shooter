using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthUI : MonoBehaviour {

	private Text healthText;
	void Awake () {
		healthText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		healthText.text = "Health: " + PlayerStatsManager.GetPlayerHealth ();
	}
}
