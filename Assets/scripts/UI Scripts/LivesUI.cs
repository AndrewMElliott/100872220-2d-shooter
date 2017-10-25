using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LivesUI : MonoBehaviour {

	private Text lifeText;
	void Awake () {
		lifeText = GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () {
		lifeText.text = "Lives: " + PlayerStatsManager.GetPlayerLives ();
	}
}
