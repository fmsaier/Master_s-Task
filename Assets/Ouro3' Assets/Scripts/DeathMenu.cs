using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ouro3
{
    public class DeathMenu : MonoBehaviour
    {
        private bool isOpen = false;
        public GameObject deathPenal;
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void BackToMenu()
        {
            SceneManager.LoadScene("MainMenu");
            Time.timeScale = 1;
        }

        public void QuitGame()
        {
            Application.Quit();
        }
        public void Open()
        {
            Time.timeScale = 0;
            deathPenal.gameObject.SetActive(true);
            isOpen = true;

        }
        public void Close()
        {
            Time.timeScale = 1;
            deathPenal.gameObject.SetActive(false);
            isOpen = false;

        }
    }

}