using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public Transform waypointParent;
	public float moveSpeed = 2f;
	public float stoppingDistance = 1f;
	public float gravityDistance = 2f;

	private Transform[] waypoints;
	private int currentIndex = 1;

	// Use this for initialization
	void Start() {
		// Get all children from waypointParent
		waypoints = waypointParent.GetComponentsInChildren<Transform>();
	}

	// Update is called once per frame
	void Update() {
		Patrol();
	}

	void OnDrawGizmos() {
		if (waypoints != null && waypoints.Length > 0) {

		Transform point = waypoints[currentIndex];
		Gizmos.color = Color.cyan;
		Gizmos.DrawLine(this.transform.position, point.position);
		Gizmos.color = Color.magenta;
		Gizmos.DrawWireSphere(point.position, stoppingDistance);
		}
	}

	void Patrol() {
		// Get the current waypoint
		Transform point = waypoints[currentIndex];
		// Get distance from waypoint
		float distance = Vector3.Distance(this.transform.position, point.position);

		/*if (distance < gravityDistance) {
			this.getComponent<Rigidbody>().useGravity = true;
		}
		else {
			this.getComponent<Rigidbody>().useGravity = false;
		}*/

		// If dist < stopping dist
		if (distance < stoppingDistance) {
			currentIndex++;
			if (currentIndex >= waypoints.Length) { currentIndex = 1; }
		}
		// Move to next waypoint
		this.transform.position = Vector3.MoveTowards(this.transform.position, point.position, moveSpeed * Time.deltaTime);
		this.transform.LookAt(point.position);
		// Move Enemy towards current waypoint
	}
}
