using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour {

	public float maxLeft = 3f;
	public float maxRight = 3f;
	public float speed = 1f;

//	NavMeshAgent navMeshAgent;
	Vector3 initialPosition;

	Vector3 maxLeftPosition;
	Vector3 maxRightPosition;
	Vector3 destination;
	bool isGoingLeft = true;

	void Start() {
//		navMeshAgent = GetComponent<NavMeshAgent>();
		initialPosition = transform.position;

		Debug.Log("initialPosition" + initialPosition);

		maxLeftPosition = new Vector3(
			initialPosition.x - maxLeft,
			initialPosition.y,
			initialPosition.z
		);
		maxRightPosition = new Vector3(
			initialPosition.x + maxRight,
			initialPosition.y,
			initialPosition.z
		);

		destination = maxLeftPosition;

		Debug.Log("go to: " + destination);
	}

	void Update() {
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, destination, step);

		if (HasReachedPosition()) {
			Debug.Log("HasReachedPosition");
			isGoingLeft = !isGoingLeft;
			destination = isGoingLeft ? maxLeftPosition : maxRightPosition;
		}
	}

	void LateUpdate() {
		transform.SetY(initialPosition.y);
	}

	bool HasReachedPosition() {
		if (isGoingLeft) {
			return transform.position == maxLeftPosition;
		} else {
			return transform.position == maxRightPosition;
		}
	}

//	bool HasReachedPosition() {
//		float dist = navMeshAgent.remainingDistance;
//
//		return !float.IsPositiveInfinity(dist)
//			&& navMeshAgent.pathStatus == NavMeshPathStatus.PathComplete
//			&& navMeshAgent.remainingDistance == 0;
//	}

}
