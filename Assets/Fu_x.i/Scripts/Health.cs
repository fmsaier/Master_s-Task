using UnityEngine;
using UnityEngine.UI;

namespace Fu_x.i
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 100f;

        [SerializeField] [Range(0, 100)] private float currentHealth = 100f;

        public SpriteRenderer sr;
        public Image healthFill;

        private void Start()
        {
            sr = GetComponent<SpriteRenderer>();
        }

        public void ChangeHealth(float amount)
        {
            currentHealth += amount;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
            UpdateSprite();
            if (currentHealth <= 0) Die();
        }

        private void UpdateSprite()
        {
            var percentage = currentHealth / maxHealth;
            percentage = Mathf.Clamp(percentage, 0, 1);
            var color = sr.color;
            color = new Color(color.r, color.g, color.b, percentage);
            sr.color = color;
            healthFill.fillAmount = percentage;
        }

        private void Die()
        {
            Time.timeScale = 0;
            Manager.Instance.GameOver();
        }
    }
}