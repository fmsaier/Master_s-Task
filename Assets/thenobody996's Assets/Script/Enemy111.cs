using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Thenobody
{
    public class Enemy111 : MonoBehaviour
    {
        public GameObject Canvas;
        RectTransform RectTransform;
        private Button button;
        public int enemytype;
        Rigidbody2D rb;
        public float speed;
        public float generatetime;
        [SerializeField] private float time; 
        public void Start()
        {
            Canvas = GameObject.Find("Canvas");
            RectTransform = Canvas.GetComponent<RectTransform>();
            rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0, -RectTransform.rect.height / 5f);
            time = 0;
            button = GetComponent<Button>();
            button.onClick.AddListener(OnClick);
            HabitsScore.instance.onEnd += OnEnd;
        }
        private void Update()
        {
            time += Time.deltaTime;
            if (time > generatetime)
            {
                if (enemytype == 0)
                    HabitsScore.instance.Punish();
                Destroy(gameObject);
            }
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
