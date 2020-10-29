using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorPad : MonoBehaviour
{
    private Transform _box;
    private Rigidbody _boxRbd;
    private void Awake()
    {
        _box = GameObject.Find("Cube").GetComponent<Transform>();
        _boxRbd = GameObject.Find("Cube").GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_box.transform.position.x <= transform.position.x)
        {
            Debug.Log("alcanzado");
            _boxRbd.isKinematic = true;
        }
    }
}
