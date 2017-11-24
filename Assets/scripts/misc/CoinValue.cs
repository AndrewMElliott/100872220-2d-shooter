/* Source File: Scripts/misc
 * Author: Andrew Elliott
 * 
 * Last Modified by: Andrew Elliott
 * 
 * Revision History:
 * October 24, 2017
 * November 23, 2017
 * 
 * Description: Sets behavior for coins
 * */

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

	//return coin value;
	public float GetCoinValue(){
		return coinValue;
	}
	//increase upgrade points in player manager.
	public void PassUpgradeValue(){
		PlayerStatsManager.SetUpgradePoints (coinUpgradeValue);
	}

	void Start(){
		DestroyObject (gameObject, coinLife);
	}


}
