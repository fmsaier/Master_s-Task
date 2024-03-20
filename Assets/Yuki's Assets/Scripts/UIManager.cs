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
    }
}

