using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Lamya.whackamole
{
    public class GameOver : MonoBehaviour
    {

        public static GameOver Instance;
        [SerializeField] private GameObject elements;
        [SerializeField] private GameObject bg;
        [SerializeField] private TextMeshProUGUI highScoreText;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
                Destroy(gameObject);
        }

        public void GameEnded(int score)
        {
            highScoreText.text = score.ToString();
            elements.SetActive(true);
            bg.SetActive(true);
            LeanTween.scale(elements, Vector3.one, 0.2f);

        }


        public void RestartGame(int level)
        {
            SceneManager.LoadScene(level);
        }

        public void MainMenuLoad()
        {
            SceneManager.LoadScene(0);
        }
    }
}


