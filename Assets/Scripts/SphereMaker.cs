using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SphereMaker : MonoBehaviour
{
    [SerializeField] private GameObject[] _initialSpheres;
    [SerializeField] private Transform[] _positions;
    [SerializeField] private Vector2 _periodRange;

    private float _period;

    void Update()
    {
        _period -= Time.deltaTime;
        if (_period <= 0.0f)
        {
            _period = Random.Range(_periodRange.x, _periodRange.y);
            var sphere = _initialSpheres[Random.Range(0, _initialSpheres.Length)];
            var pos = _positions[Random.Range(0, _positions.Length)];
            Instantiate(sphere, pos.localPosition, pos.localRotation).SetActive(true);
        }
    }
}
