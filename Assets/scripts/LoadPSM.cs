using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPSM : MonoBehaviour {

	public GameObject playerStatsManager;
	void Awake () {
		if (PlayerStatsManager.instance == null) {
			Instantiate (playerStatsManager);
		}
	}
	


}
