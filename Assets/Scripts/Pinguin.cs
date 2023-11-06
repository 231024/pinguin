using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinguin : MonoBehaviour
{
    private int _collectedPoints;
    
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    
    private void OnCollisionEnter(Collision other)
    {
        Sphere collisionSphere = other.gameObject.GetComponent<Sphere>();
        if (collisionSphere != null)
        {
            _collectedPoints = _collectedPoints + collisionSphere.Points;
            Debug.Log($"I'm a pinguin and have {_collectedPoints} points");
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * (_speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * (_speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -90.0f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, 90.0f * Time.deltaTime);

        }
    }
}
