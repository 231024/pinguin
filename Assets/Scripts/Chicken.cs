using UnityEngine;
using UnityEngine.AI;

public class Chicken : MonoBehaviour
{
	private const string WayPointTag = "WayPoint";
	[SerializeField] private NavMeshAgent _agent;
	[SerializeField] private Transform[] _wayPoints;

	private int _currentWayPointIndex;
	private Transform _target;

	public int CollectedPoints { get; private set; }

	private void Start()
	{
		_target = _wayPoints[_currentWayPointIndex].transform;
	}

	private void Update()
	{
		if (_target == null)
		{
			return;
		}

		transform.LookAt(_target);
		_agent.SetDestination(_target.position);
	}

	private void OnCollisionEnter(Collision other)
	{
		var collisionSphere = other.gameObject.GetComponent<Sphere>();
		if (collisionSphere != null)
		{
			_target = _wayPoints[_currentWayPointIndex].transform;
			CollectedPoints += collisionSphere.Points;
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

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.GetComponentInParent<Sphere>() != null)
		{
			Debug.Log("Sphere was lost");
			_target = _wayPoints[_currentWayPointIndex].transform;
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
}
