using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Thenobody
{
    public class Enemy111 : MonoBehaviour
    {
        private Button button;
        public int enemytype;
        Rigidbody2D rb;
        public float speed;
        public void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0, -speed);
            button = GetComponent<Button>();
            button.onClick.AddListener(OnClick);
            HabitsScore.instance.onEnd += OnEnd;
        }
        private void OnClick()
        {
            Destroy(this.gameObject);
            HabitsScore.instance.ScoreUpdate(enemytype);
        }
        private void OnEnd()
        {
            Destroy(this.gameObject);
        }
        private void OnDestroy()
        {
            HabitsScore.instance.onEnd -= OnEnd;
        }
    }
}
