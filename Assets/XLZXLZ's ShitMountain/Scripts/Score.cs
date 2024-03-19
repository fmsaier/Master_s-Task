using UnityEngine;
using UnityEngine.UI;

namespace XLZXLZ
{
    public class Score : MonoBehaviour
    {
        public static Score instance;

        public float downPerSec = 0.5f;
        public float currentScore = 10;
        public float targetScore = 100;

        public bool isStart;
        private Slider scoreSlider;

        [SerializeField]
        private GameObject winPannel;
        [SerializeField]
        private GameObject losePannel;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            scoreSlider = GetComponent<Slider>();
        }

        public void UpdateScore(float value)
        {
            currentScore += value;
            currentScore = Mathf.Clamp(currentScore, 0, targetScore);

            if (scoreSlider != null)
            {
                float sliderValue = currentScore / targetScore;
                scoreSlider.value = sliderValue;
            }

            // 在这里可以添加其他与分数相关的逻辑
        }

        private void Update()
        {
            if (!isStart)
                return;
            currentScore -= Time.deltaTime * downPerSec;
            scoreSlider.value = Mathf.Lerp(scoreSlider.value, currentScore / targetScore, Time.deltaTime);

            if (currentScore >= targetScore)
                Win();

            if (currentScore <= 0)
                Lose();
        }

        private void Win()
        {
            Time.timeScale = 0;
            winPannel.SetActive(true);
        }

        private void Lose()
        {
            Time.timeScale = 0;
            losePannel.SetActive(true);
        }
    }
}