using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : MonoBehaviour {

	public Transform waypointParent;
	public float stoppingDistance = 1f;

	private NavMeshAgent agent;
	private Transform[] waypoints;
	private int currentIndex = 1;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		waypoints = waypointParent.GetComponentsInChildren<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		Transform point = waypoints[currentIndex];
		float distance = Vector3.Distance(this.transform.position, point.position);
		if (distance < stoppingDistance) {
			currentIndex++;
			if (currentIndex >= waypoints.Length) { currentIndex = 1; }
		}
		agent.SetDestination(point.position);
	}
}
