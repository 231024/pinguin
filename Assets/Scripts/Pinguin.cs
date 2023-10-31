using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinguin : MonoBehaviour
{
    private int _collectedPoints;
    public float _speed;
    public float _rotationSpeed;
    
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
            var tmp = transform.localPosition;
            tmp.z += _speed * Time.deltaTime;
            transform.localPosition = tmp;
        }
        if (Input.GetKey(KeyCode.S))
        {
            var tmp = transform.localPosition;
            tmp.z -= _speed * Time.deltaTime;
            transform.localPosition = tmp;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Quaternion tmp = transform.localRotation;
            tmp.y -= _rotationSpeed * Time.deltaTime;
            transform.localRotation = tmp;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Quaternion tmp = transform.localRotation;
            tmp.y += _rotationSpeed * Time.deltaTime;
            transform.localRotation = tmp;
        }
    }
}
