using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Lamya.whackamole
{
    public class GameManager : MonoBehaviour
    {

        public static GameManager Instance;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private TextMeshProUGUI gameTimeText;
        [SerializeField] private float gameTimer;
        [SerializeField] public float timer;
        private float fixedTimer;

        //array of Moles
        [SerializeField] Mole[] moles = new Mole[7];

        private int score;
        int Score
        {
            get => score;
            set
            {
                score = value;
                scoreText.text = score.ToString();
            }
        }

        private bool gameEnded = false;
        public bool GameEnded => gameEnded;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                return;
            }
            Destroy(gameObject);
        }

        private void Start()
        {
            fixedTimer = timer;
        }
        // Update is called once per frame
        void Update()
        {
            if (!gameEnded)
            {
                if (gameTimer > 0)
                {
                    gameTimer -= Time.deltaTime;
                    timer -= Time.deltaTime;
                    gameTimeText.text = gameTimer.ToString("00s");
                }
                else
                {
                    gameTimer = 0;
                    gameEnded = true;
                }

                if (timer <= 0)
                {
                    RandomMole();
                    timer = fixedTimer; //resets the time 
                }
            }
            else
            {
                GameEnds();
            }
        }

        public void IncreaseScore()
        {
            Score++;
        }

        private void RandomMole()
        {
            moles[(int)UnityEngine.Random.Range(0, moles.Length - 1)].SetMovingUp(true);
        }

        private void GameEnds()
        {
            for (int i = 0; i < moles.Length; i++)
            {
                moles[i].SetMovingUp(false);
            }
            GameOver.Instance.GameEnded();
        }

    }
}


/*
 * 
 * yield keyword??
 * static gameobjects
 * 
 */


