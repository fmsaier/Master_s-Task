using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
            Time.timeScale = 1;
        }

        public void BackToMenu()
        {
            Time.timeScale = 1;
        }

        public void Pause()
        {
            
        }

        public void GameOver()
        {
            Time.timeScale = 0;
            finalScoreText.text = player.score.ToString();
            gameOverPanel.SetActive(true);
        }
    }
}

