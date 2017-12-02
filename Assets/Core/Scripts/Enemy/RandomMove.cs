using UnityEngine;
using UnityEngine.AI;

public class RandomMove : MonoBehaviour {

	public float moveRadiusFromStart = 5f;

	Vector3 startPosition;
	NavMeshAgent navMeshAgent;

	// Use this for initialization
	void Start () {
		navMeshAgent = GetComponent<NavMeshAgent>();
		startPosition = transform.position;
	}
	
	void Update () {
		if (HasReachedPosition()) {
			navMeshAgent.destination = GetNextPosition();
		}
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
