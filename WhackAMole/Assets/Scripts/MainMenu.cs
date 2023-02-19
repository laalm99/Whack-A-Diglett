using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

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
            PlayerPrefs.SetInt("level", level);
            SceneManager.LoadScene(1);
        }

    }
}

