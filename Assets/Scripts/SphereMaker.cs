using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMaker : MonoBehaviour
{
    public GameObject _initialSphere;
    public Transform _position;

    public float _period;

    void Update()
    {
        _period = _period - Time.deltaTime;
        if (_period <= 0.0f)
        {
            _period = 1.0f;
            Instantiate(_initialSphere, _position.localPosition, _position.localRotation).SetActive(true);
        }
    }
}
