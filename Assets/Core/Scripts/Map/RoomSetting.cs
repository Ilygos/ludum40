using UnityEngine;
using System;

public class RoomSetting : MonoBehaviour {

	public EnemyWave[] waves;
	public GameObject DoorToOpenAtEnd;

	Transform enemiesHolder;
	int currentWave = 0;
	Transform enemiesSpawn;

	void Start () {
		enemiesHolder = GameObject.Find("/Environment/Actors/Enemies").transform;
		enemiesSpawn = transform.Find("Spawner/Enemy");

		if (waves.Length == 0) {
			Debug.LogWarning("No wave configured");
		}
	}
	
	public void Init() {
		StartNewWave();
	}

	void StartNewWave() {
		GameObject[] enemyWave = waves[currentWave].enemies;
		int i = 0;
		int nbEnemyInWave = enemyWave.Length;

		foreach (GameObject enemyPrefab in enemyWave) {
			Vector3 baseSapwnPosition = enemiesSpawn.position;
			Vector3 position = new Vector3(
				baseSapwnPosition.x + (float)i,
				0,
				baseSapwnPosition.z
			);

			GameObject newEnemy = Instantiate(enemyPrefab, position, enemyPrefab.transform.rotation, enemiesHolder);

			var healthComp = newEnemy.GetComponent<Health>();

			healthComp.OnDead += () => {
				Debug.Log("Monster dead ;)");
				nbEnemyInWave--;

				if (nbEnemyInWave <= 0) {
					currentWave++;

					if (currentWave >= waves.Length) {
						Debug.Log("Room win");
						DoorToOpenAtEnd.SetActive(false);
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
