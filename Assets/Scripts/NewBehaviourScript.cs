using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject[] _gb;

    private int _testVar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.LogWarning($"ETO AD");
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.LogError($"Test Var value is {_testVar}");
            ++_testVar;
            Debug.Log($"Test Var value is {_testVar}");
        }
    }
}
