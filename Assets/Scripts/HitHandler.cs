using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitHandler : MonoBehaviour
{
	public GameObject _initialObject;
	public Transform _position;
	
    private void OnCollisionEnter(Collision other)
    {
        // Destroy(gameObject);

        // var go = Instantiate(_initialObject, _position);
        // go.SetActive(true);
        Instantiate(Resources.Load("CubeBase"));
    }
}
