using UnityEngine;
using System;

public class RoomSetting : MonoBehaviour {

	public EnemyWave[] waves;

	Transform enemiesHolder;
	int currentWave = 0;

	void Start () {
		enemiesHolder = GameObject.Find("/Environment/Actors/Enemies").transform;

		if (waves.Length == 0) {
			Debug.LogWarning("No wave configured");
		} else {
			StartNewWave();
		}
	}
	
	void Update () {
	}

	void StartNewWave() {
		GameObject[] enemyWave = waves[currentWave].enemies;
		int i = 0;
		int nbEnemyInWave = enemyWave.Length;

		foreach (GameObject enemyPrefab in enemyWave) {
			Vector3 position = new Vector3(-4f + (float)i, 0, -3);

			GameObject newEnemy = Instantiate(enemyPrefab, position, enemyPrefab.transform.rotation, enemiesHolder);

			var healthComp = newEnemy.GetComponent<Health>();

			healthComp.OnDead += () => {
				Debug.Log("Monster dead ;)");
				nbEnemyInWave--;

				if (nbEnemyInWave <= 0) {
					currentWave++;

					if (currentWave >= waves.Length) {
						Debug.Log("Room win");
					} else {
						StartNewWave();
					}
				}
			};

			i++;
		}
	}

	[Serializable]
	public class EnemyWave {
		public GameObject[] enemies;
	}

}
