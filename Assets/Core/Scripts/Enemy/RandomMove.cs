using UnityEngine;
using UnityEngine.AI;

public class RandomMove : MonoBehaviour {

	public float moveRadiusFromStart = 5f;

	Vector3 startPosition;
	NavMeshAgent navMeshAgent;
	Vector3 initialPosition;

	void Start() {
		navMeshAgent = GetComponent<NavMeshAgent>();
		startPosition = transform.position;
		initialPosition = transform.position;
	}

	void Update() {
		if (HasReachedPosition()) {
			navMeshAgent.destination = GetNextPosition();
		}
	}

	void LateUpdate() {
		transform.SetY(initialPosition.y);
	}

	bool HasReachedPosition() {
		float dist = navMeshAgent.remainingDistance;

		return !float.IsPositiveInfinity(dist)
		&& navMeshAgent.pathStatus == NavMeshPathStatus.PathComplete
		&& navMeshAgent.remainingDistance == 0;
	}

	Vector3 GetNextPosition() {
		Vector3 randomDirection = Random.insideUnitSphere * moveRadiusFromStart;

		randomDirection += startPosition;

		NavMeshHit hit;
		NavMesh.SamplePosition(randomDirection, out hit, moveRadiusFromStart, 1);

		return hit.position;
	}

}
