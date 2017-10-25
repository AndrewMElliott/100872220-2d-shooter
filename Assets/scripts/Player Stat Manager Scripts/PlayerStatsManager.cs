using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsManager : MonoBehaviour {

	public static PlayerStatsManager instance = null;
	private static float playerHealth = 5f;
	private static float playerScore = 0f;
	private static float upgradePoints = 0f;
	private static float playerLives = 3f;
	private static bool canSpawn = true;
	// Use this for initialization
	void Awake () {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		ResetStats ();
	}

	public static void ResetStats(){
		playerHealth = 5f;
		playerScore = 0f;
		upgradePoints = 0f;
		playerLives = 3f;
		canSpawn = true;
	}
	public static  float GetPlayerHealth(){
		return playerHealth;
	}
	public static float GetPlayerScore(){
		return playerScore;
	}
	public static float GetUpgradePoints(){
		return upgradePoints;
	}
	public static float GetPlayerLives(){
		return playerLives;
	}
	public static bool GetCanSpawn(){
		return canSpawn;
	}
	public static void SetCanSpawn(bool spawn){
		canSpawn = spawn;
	}
	public static void SetPlayerLives(float life){
		playerLives = life;
	}
	public static void DecrementPlayerLives(float life){
		playerLives -= life;
	}
	public static void SetPlayerHealth(float health){
		if (playerHealth + health < 0) {
			playerHealth = 0;
		} else {
			playerHealth += health;
		}
	}
	public static void SetPlayerScore(float score){
		playerScore += score;
	}
	public static void SetUpgradePoints(float points){
		if (upgradePoints + points >= 20f) {
			upgradePoints = 20f;
		}else if(upgradePoints + points < 0){
			upgradePoints = 0f;		
		} else {
			upgradePoints += points;
		}
	}
}
