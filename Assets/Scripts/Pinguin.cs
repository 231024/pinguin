using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pinguin : MonoBehaviour
{
    private int _collectedPoints;

    public int CollectedPoints => _collectedPoints;

    [SerializeField] private float _speed;
    [SerializeField] private float _dashSpeed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Rigidbody _body;
    [SerializeField] private GameObject _target;

    private bool _isGrounded;
    
    private void OnCollisionEnter(Collision other)
    {
        Sphere collisionSphere = other.gameObject.GetComponent<Sphere>();
        if (collisionSphere != null)
        {
            _collectedPoints += collisionSphere.Points;
        }

        _isGrounded = true;
    }

    private void OnCollisionExit(Collision other)
    {
        _isGrounded = false;
    }

    private void Update()
    {
        RaycastHit hitInfo = new RaycastHit();
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo))
        {
            Debug.Log(hitInfo.collider.name);
        }
        
        _body.AddRelativeForce(new Vector3(0.0f, 0.0f, Input.GetAxis("Vertical")) * _speed);
        _body.AddTorque(new Vector3(0.0f, Input.GetAxis("Horizontal"), 0.0f) * _speed);
        
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
