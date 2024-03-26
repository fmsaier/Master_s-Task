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
            SceneManager.LoadScene(1);
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

        public void Reload()
        {
            SceneManager.LoadScene("Ouro3's Scene");
            Time.timeScale = 1;
        }

        public void StartGame()
        {
            AllControl.instance.restart = true;
        }
    }

}