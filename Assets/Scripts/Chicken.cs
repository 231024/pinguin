using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : MonoBehaviour
{
    private int _wallet;
    public float _speed;
    
    private void OnCollisionEnter(Collision other)
    {
        var rock = other.gameObject.GetComponent<Rock>();
        if (rock != null)
        {
            _wallet += rock.Points;
            Debug.Log($"Chicken has {_wallet} points");
            Destroy(other.gameObject);
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
            var tmp = transform.localPosition;
            tmp.x -= _speed * Time.deltaTime;
            transform.localPosition = tmp;
        }
        if (Input.GetKey(KeyCode.D))
        {
            var tmp = transform.localPosition;
            tmp.x += _speed * Time.deltaTime;
            transform.localPosition = tmp;
        }
    }
}
