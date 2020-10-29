using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _manager;
    public static GameManager Manager
    {
        get
        {
            if (_manager == null)
            {
                Debug.Log("GameManager is null");
            }
            return _manager;
        }
    }


    public int _score;
    public int _lives;

    private void Awake()
    {
        _manager = this;
    }

    private void Start()
    {
        _score = 0;
        _lives = 3;
    }
}
