using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinValue : MonoBehaviour {
	[SerializeField]
	private float coinValue = 2f;
	[SerializeField]
	private float coinLife = 5f;
	[SerializeField]
	private float coinUpgradeValue = 1f;

	public float GetCoinValue(){
		return coinValue;
	}

	public void PassUpgradeValue(){
		PlayerStatsManager.SetUpgradePoints (coinUpgradeValue);
	}

	void Start(){
		DestroyObject (gameObject, coinLife);
	}


}
