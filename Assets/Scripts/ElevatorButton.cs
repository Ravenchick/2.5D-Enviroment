using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButton : MonoBehaviour
{
    [SerializeField] private MeshRenderer _lightRender;

    [SerializeField] private Material doorOpen;

    private bool isElevatorHere = false;

    private Elevator _elevatorScript;

    private bool _active = false;

    //bottom is 0 and top is 1
    [SerializeField] private int buttonId;


    private void Awake()
    {
        _elevatorScript = GameObject.Find("Elevator").GetComponent<Elevator>();
    }

    private void Update()
    {
        if (GameManager.Manager._score >= 12)
        {
            _lightRender.material = doorOpen;
            _active = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E) && _active == true)
        {
            _elevatorScript.MoveElevator(buttonId);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Elevator"))
        {
            isElevatorHere = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Elevator"))
        {
            isElevatorHere = false;
        }
    }
}
