using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Thenobody
{
    public class UIManager : MonoBehaviour
    {
        public GameObject startpanel;
        public GameObject endpanel;
        public GameObject pausepanel;

        private void OnEnable()
        {
            Time.timeScale = 0f;
            HabitsScore.instance.onEnd += EndGame;
        }

        public void StartGame()
        {
            startpanel.SetActive(false);
            Time.timeScale = 1.0f;
        }
        public void EndGame()
        {
            Time.timeScale = 0f;
            endpanel.SetActive(true);
            HabitsScore.instance.onEnd -= EndGame;
        }
        public void PauseGame()
        {
            pausepanel.SetActive(true);
            Time.timeScale = 0f;
        }

        public void Continue()
        {
            pausepanel.SetActive(false);
            Time.timeScale = 1f;
        }
        public void NewGame()
        {
            SceneManager.LoadScene("thenobody996's Scene");
            endpanel.SetActive(false);
        }

        public void back()
        {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene(1);
        }
    }
}
