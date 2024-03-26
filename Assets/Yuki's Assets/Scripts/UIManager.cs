using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Yuki
{
    public class UIManager : MonoBehaviour
    {
        private PlayerController player;

        public Text scoreText;
        public Text livesText;
        public Text specialShotText;

        public GameObject gameOverPanel;
        public Text finalScoreText;

        public GameObject pausePanel;
        private bool isPause;

        public GameObject introduction;

        private void Start()
        {
            player = GameObject.Find("Player").GetComponent<PlayerController>();
        }

        private void Update()
        {
            scoreText.text = player.score.ToString();
            livesText.text = player.lives.ToString();
            specialShotText.text = player.specialShotTimes.ToString();
        }

        public void PlayAgain()
        {
            SceneManager.LoadScene("Yuki's GameScene");
            Time.timeScale = 1;
        }

        public void BackToMenu()
        {
            SceneManager.LoadScene(1);
            Time.timeScale = 1;
        }

        public void GameStart()
        {
            introduction.SetActive(false);
            Time.timeScale = 1;
        }

        public void Pause()
        {
            if (!isPause)
            {
                Time.timeScale = 0;
                isPause = true;
                pausePanel.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                isPause = false;
                pausePanel.SetActive(false);
            }
        }

        public void GameOver()
        {
            Time.timeScale = 0;
            finalScoreText.text = player.score.ToString();
            gameOverPanel.SetActive(true);
        }
    }
}

