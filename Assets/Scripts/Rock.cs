using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
	public int _points;

	public int Points => _points;

	public float _timeToDestroy;

	private void Update()
	{
		_timeToDestroy -= Time.deltaTime;
		if (_timeToDestroy <= 0.0f)
		{
			Destroy(gameObject);
		}
	}
}

