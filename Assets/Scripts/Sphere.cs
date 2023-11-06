using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField] private float _timeToDestroy;
    [SerializeField] private int _points;

    public int Points => _points;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Pinguin>() != null)
        {
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        _timeToDestroy -= Time.deltaTime;
        if (_timeToDestroy <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
