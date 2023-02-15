using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Lamya.whackamole
{
    public class GameOver : MonoBehaviour
    {

        public static GameOver Instance;
        [SerializeField] private GameObject elements;
        [SerializeField] private GameObject bg;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
                Destroy(gameObject);
        }

        public void GameEnded()
        {
            elements.SetActive(true);
            bg.SetActive(true);
            LeanTween.scale(elements, Vector3.one, 0.2f);

        }


        public void RestartGame()
        {
            SceneManager.LoadScene(1);
        }

        public void MainMenuLoad()
        {
            SceneManager.LoadScene(0);
        }
    }
}


