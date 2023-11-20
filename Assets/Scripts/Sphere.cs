using UnityEngine;

public class Sphere : MonoBehaviour
{
	[SerializeField] private float _timeToDestroy;
	[SerializeField] private int _points;

	public int Points => _points;

	private void Update()
	{
		_timeToDestroy -= Time.deltaTime;
		if (_timeToDestroy <= 0.0f)
		{
			Destroy(gameObject);
		}
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.GetComponent<Pinguin>() != null || other.gameObject.GetComponent<Chicken>() != null)
		{
			Destroy(gameObject);
		}
	}
}
