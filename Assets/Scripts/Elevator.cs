using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private Vector3 botPosition;
    [SerializeField] private Vector3 topPosition;
    [SerializeField] private Vector3 tarjet;
    [SerializeField] private int speed;
    private Rigidbody _rbd;

    private void Awake()
    {
        _rbd = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        tarjet = transform.position;
    }

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, tarjet, speed * Time.deltaTime);
    }

    public void MoveElevator(int Id)
    {
        if(Id == 0 && transform.position == topPosition)
        {
            tarjet = botPosition;
        }
        if(Id == 1 && transform.position == botPosition)
        {
            tarjet = topPosition;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.G))
        {
            if (tarjet == botPosition)
            {
                tarjet = topPosition;
            }
            else
            {
                tarjet = botPosition;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = this.transform;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = null;

        }
    }
}
