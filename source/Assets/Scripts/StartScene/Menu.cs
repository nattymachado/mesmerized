﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace StartMenu
{
    public class Menu : MonoBehaviour
    {
        [SerializeField] private string _nextScene;
        [SerializeField] private GameObject _configurationPanel;
        [SerializeField] private GameObject _principalPanel;
        [SerializeField] private GameObject _creditsPanel;
        [SerializeField] private Slider _bgmSlider;
        [SerializeField] private Slider _sfxSlider;

        public void Play()
        {
            SceneChanger.Instance.ChangeToScene(_nextScene);
        }

        public void Configuration()
        {
            _configurationPanel.SetActive(true);
            _principalPanel.SetActive(false);
            _creditsPanel.SetActive(false);
        }


        public void Credits()
        {
            _configurationPanel.SetActive(false);
            _principalPanel.SetActive(false);
            _creditsPanel.SetActive(true);
        }

        public void CloseConfiguration()
        {
            _configurationPanel.SetActive(false);
            _principalPanel.SetActive(true);
            _creditsPanel.SetActive(false);
        }

        public void CloseCredits()
        {
            _configurationPanel.SetActive(true);
            _principalPanel.SetActive(false);
            _creditsPanel.SetActive(false);
        }

        public void UpdateSFXVolume()
        {
            GameEvents.AudioEvents.SetSFXVolume.SafeInvoke(_sfxSlider.value);
        }

        public void UpdateBGMVolume()
        {
            GameEvents.AudioEvents.SetBGMVolume.SafeInvoke(_bgmSlider.value);
        }

        public void Quit()
        {
            Application.Quit();

        }
    }
}