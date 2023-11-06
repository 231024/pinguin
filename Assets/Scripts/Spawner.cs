using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject _initialObject;
    public float _timer = 1.0f;

    private float _cachedTimer;

    private void Start()
    {
        _cachedTimer = _timer;
    }

    void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0.0f)
        {
            Instantiate(_initialObject, transform.localPosition, transform.localRotation);
            _timer = _cachedTimer;
        }
    }
}
