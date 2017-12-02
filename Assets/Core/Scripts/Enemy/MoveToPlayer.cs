using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class MoveToPlayer : MonoBehaviour {

	public float refreshPositionDelay = 1f;

	Vector3 startPosition;
	NavMeshAgent navMeshAgent;
	Transform player;

	void Start() {
		navMeshAgent = GetComponent<NavMeshAgent>();
		player = GameObject.Find("/Environment/Actors/Player").transform;

		StartCoroutine(MoveTowardPlayer());
	}

	IEnumerator MoveTowardPlayer() {
		while(true) {
			yield return new WaitForSeconds(refreshPositionDelay);

			navMeshAgent.destination = player.position;
		}
	}

}
