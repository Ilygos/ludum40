using UnityEngine;
using System;

public class RoomSetting : MonoBehaviour {

	public EnemyWave[] waves;

	Transform enemiesHolder;
	int currentWave = 0;

	void Start () {
		enemiesHolder = GameObject.Find("/Environment/Actors/Enemies").transform;
		StartNewWave(currentWave);
	}
	
	void Update () {
	}

	void StartNewWave(int waveNumber) {
		GameObject[] enemyWave = waves[waveNumber].enemies;
		int i = 0;

		foreach (GameObject enemyPrefab in enemyWave) {
			Vector3 position = new Vector3(-4f + (float)i, 0, -3);

			Instantiate(enemyPrefab, position, enemyPrefab.transform.rotation, enemiesHolder);
			i++;
		}
	}

	[Serializable]
	public class EnemyWave {
		public GameObject[] enemies;
	}

}
