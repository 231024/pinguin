using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pinguin : MonoBehaviour
{
    private int _collectedPoints;
    
    [SerializeField] private float _speed;
    [SerializeField] private float _dashSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Rigidbody _body;

    private bool _isGrounded;
    
    private void OnCollisionEnter(Collision other)
    {
        Sphere collisionSphere = other.gameObject.GetComponent<Sphere>();
        if (collisionSphere != null)
        {
            _collectedPoints = _collectedPoints + collisionSphere.Points;
            Debug.Log($"I'm a pinguin and have {_collectedPoints} points");
        }

        _isGrounded = true;
    }

    private void OnCollisionExit(Collision other)
    {
        _isGrounded = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _body.AddRelativeForce(Vector3.forward * _speed, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _body.AddRelativeForce(Vector3.back * _speed, ForceMode.Acceleration);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _body.AddTorque(Vector3.down * _speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _body.AddTorque(Vector3.up * _speed);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _body.AddForce(Vector3.up * _jumpForce);
        }
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _body.AddRelativeForce(Vector3.forward * _dashSpeed, ForceMode.Impulse);
        }
    }
}
