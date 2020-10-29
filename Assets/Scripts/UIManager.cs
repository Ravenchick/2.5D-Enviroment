using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    private static UIManager manager;
    public static UIManager Manager
    {
        get
        {
            if(manager == null)
            {
                Debug.LogError("UIManager is null");
            }

            return manager;
        }
    }
    
    private TMP_Text score;
    private TMP_Text lives;
    private void Awake()
    {
        manager = this;
        score = GameObject.Find("Score").GetComponent<TMP_Text>();
        lives = GameObject.Find("Lives").GetComponent<TMP_Text>();
    }

    private void Update()
    {
        score.text = "Score: " + GameManager.Manager._score.ToString();
        lives.text = "Lives: " + GameManager.Manager._lives.ToString();

    }


}
