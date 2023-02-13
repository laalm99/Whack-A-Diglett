using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI gameTimeText;
    [SerializeField] private float gameTimer;
    [SerializeField] public float timer;
    private int score = 0;
    private bool gameEnded = false;

    //array of Moles
    [SerializeField] Mole[] moles = new Mole[7];

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
       // gameTimer -= Time.deltaTime;
       // timer -= Time.deltaTime;

        if (gameTimer >= 0) {
            gameTimer -= Time.deltaTime;
            timer -= Time.deltaTime;
            gameTimeText.text = gameTimer.ToString("00s");
        }
        else
        {
            gameTimer = 0;
            gameEnded = true;
        }

        if (timer <= 0 && !gameEnded)
        {
            RandomMole();
            timer = 2f; //resets the time 
        }

        if (gameTimer <= 0)
        {
           for(int i=0; i<moles.Length; i++)
            {
                moles[i].SetMovingUp(false);
            }
            score = 0;
            gameEnded = true;
        }
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    private void RandomMole()
    {
        moles[(int)UnityEngine.Random.Range(0,6)].SetMovingUp(true);
    }
}

