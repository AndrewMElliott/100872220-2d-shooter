using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponSystem : MonoBehaviour {
	[SerializeField]
	private float fireRate = 0.05f;
	private float fireCoolDown = 0.0f;
	[SerializeField]
	private GameObject bulletOnePrefab;
	[SerializeField]
	private GameObject bulletTwoPrefab;

	//private float upgradePoints = 0f;

	private List< float[,]> upgrades = new List<float[,]> ();


	// Use this for initialization
	void Start () {
		
		float[,] one = new float[,] {{0.3f, 0f}};
		float[,] two = new float[,] {{0.3f, -0.2f}, {0.3f, 0.2f}};
		float[,] three = new float[,] {{0.3f, -0.2f}, {0.3f, 0.2f},{0.3f, 0f}};
		upgrades.Add (one);
		upgrades.Add (two);
		upgrades.Add (three);
	}
	
	// Update is called once per frame
	void Update () {
		
		if ((Input.GetKey (KeyCode.Space) && Time.time > fireCoolDown) || (Input.GetKeyDown(KeyCode.Space))){
			if(PlayerStatsManager.GetUpgradePoints() < 10)
				Shoot (0);

			if(PlayerStatsManager.GetUpgradePoints() >= 10)
				Shoot (1);

			if(PlayerStatsManager.GetUpgradePoints() >= 20)
				Shoot (2);

			fireCoolDown = Time.time + fireRate;
		}
	}
		
		
	private void Shoot(int tier){
		for (int i = 0; i < upgrades[tier].GetLength(0) ; i++) {			
			GameObject bullet = Instantiate (bulletOnePrefab) as GameObject;
			Vector2 temp = new Vector2(transform.position.x + upgrades[tier][i,0],transform.position.y + upgrades[tier][i,1]);
			bullet.transform.position = temp;
		}
	}
}
