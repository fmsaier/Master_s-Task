using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ouro3
{
    public class PauseMenu : MonoBehaviour
    {
        private bool isOpen = false;
        public GameObject pausePenal;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!isOpen)
                {
                    Open();

                }
                else if (isOpen)
                {
                    Close();

                }
            }
        }
        public void Open()
        {
            Time.timeScale = 0;
            pausePenal.gameObject.SetActive(true);
            isOpen = true;

        }
        public void Close()
        {
            Time.timeScale = 1;
            pausePenal.gameObject.SetActive(false);
            isOpen = false;

        }

        public void BackToMenu()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(1);

        }

        public void QuitGame()
        {
            Application.Quit();
        }

    }
}
