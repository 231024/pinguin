using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public int _points;

    public int Points => _points;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Pinguin>() != null)
        {
            gameObject.SetActive(false);
        }
    }
}
