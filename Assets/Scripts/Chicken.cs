using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chicken : MonoBehaviour
{
	[SerializeField] private NavMeshAgent _agent;
	[SerializeField] private Transform[] _wayPoints;

	private int _currentWayPointIndex;
	private int _collectedPoints;
	private Transform _target;

	public int CollectedPoints => _collectedPoints;

	private const string WayPointTag = "WayPoint";

	private void Start()
	{
		_target = _wayPoints[_currentWayPointIndex].transform;
	}

	private void Update()
	{
		_agent.SetDestination(_target.position);
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.GetComponentInParent<Sphere>() != null)
		{
			Debug.Log("Sphere was lost");
			_target = _wayPoints[_currentWayPointIndex].transform;
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag(WayPointTag))
		{
			IncrementWayPoint();
			_target = _wayPoints[_currentWayPointIndex].transform;
		}
		
		if (other.gameObject.GetComponentInParent<Sphere>() != null)
		{
			_target = other.gameObject.transform.parent;
		}
	}

	private void IncrementWayPoint()
	{
		++_currentWayPointIndex;
		if (_currentWayPointIndex >= _wayPoints.Length)
		{
			_currentWayPointIndex = 0;
		}
	}
	
	private void OnCollisionEnter(Collision other)
	{
		Sphere collisionSphere = other.gameObject.GetComponent<Sphere>();
		if (collisionSphere != null)
		{
			_target = _wayPoints[_currentWayPointIndex].transform;
			_collectedPoints += collisionSphere.Points;
		}
	}
}
