using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeUI : MonoBehaviour {

	private Text upgradeCounter;

	// Use this for initialization
	void Awake () {
		upgradeCounter = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerStatsManager.GetUpgradePoints () == 20f) {
			upgradeCounter.text = "Next Upgrade: MAX";
		} else {
			upgradeCounter.text = "Next Upgrade: " + PlayerStatsManager.GetUpgradePoints () % 10 + "/10";
		}
	}
}
