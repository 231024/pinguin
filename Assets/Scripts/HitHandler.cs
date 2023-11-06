using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class HitHandler : MonoBehaviour
{
	public GameObject _initialObject;
	public Transform _position;
	
    private void OnCollisionEnter(Collision other)
    {
	    Destroy(other.gameObject);
    }
}
