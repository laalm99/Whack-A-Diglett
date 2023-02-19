using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Lamya.whackamole
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private GameObject levelPicker;
        [SerializeField] private GameObject playButton;

        public void PlayButton()
        {
            
            playButton.SetActive(false);
            levelPicker.SetActive(true);
           
        }

        public void LevelPicker(int level)
        {

            //GameManager.Instance.Level(level);
            SceneManager.LoadScene(level);
        }

    }
}