using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Fu_x.i
{
    public class Manager : MonoBehaviour
    {
        public static Manager Instance;

        public float[] intervals = { 0.5f, 2f, 4f, 6f };

        [Header("圆环内半径")] public float innerRadius = 10f;
        [Header("圆环外半径")] public float outerRadius = 12f;

        public List<GameObject> cells1;
        public List<GameObject> cells2;
        public List<GameObject> cells3;
        public List<GameObject> cells4;
        private List<List<GameObject>> _cells;

        private List<Coroutine> _coroutines;

        [Header("已消灭的癌细胞数量")] public TMP_Text killAmountText;
        public int killAmount;
        [Header("倒计时")] public TMP_Text countDownText;
        public int countDown = 60;
        private float _timer = -1;

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        private void Start()
        {
            // 将多个数组合并为一个数组
            _cells = new List<List<GameObject>> { cells1, cells2, cells3, cells4 };
            _coroutines = new List<Coroutine>();
        }

        private void Update()
        {
            if (countDown == 0) Victory();
            switch (countDown)
            {
                case < 0:
                    return;
                case < 30:
                    StartGenerating(1);
                    StartGenerating(3);
                    break;
            }

            killAmountText.text = killAmount.ToString();
            countDownText.text = countDown.ToString();
            switch (_timer)
            {
                case < 0:
                    return;
                case >= 1:
                    countDown--;
                    _timer = 0;
                    return;
                default:
                    _timer += Time.deltaTime;
                    return;
            }
        }

        public void GameStart()
        {
            _timer = 0;
            for (int i = 0; i < 4; i++)
                _coroutines.Add(StartCoroutine(GenerateCell(i, intervals[i])));
            StopGenerating(1);
            StopGenerating(3);
        }

        /// <summary>
        /// 每隔一段时间生成一个细胞
        /// </summary>
        private IEnumerator GenerateCell(int type, float interval)
        {
            while (true)
            {
                yield return new WaitForSeconds(interval);
                var angle = Random.Range(0, 360);
                var radius = Random.Range(innerRadius, outerRadius);
                var x = radius * Mathf.Cos(angle * Mathf.Deg2Rad);
                var y = radius * Mathf.Sin(angle * Mathf.Deg2Rad);
                var pos = new Vector3(x, y, 0);
                var cell = _cells[type][Random.Range(0, _cells[type].Count)];
                Instantiate(cell, pos, Quaternion.identity);
            }
        }

        private void StartGenerating(int type)
        {
            _coroutines[type] ??= StartCoroutine(GenerateCell(type, intervals[type]));
        }

        private void StopGenerating(int type)
        {
            if (_coroutines[type] == null) return;
            StopCoroutine(_coroutines[type]);
            _coroutines[type] = null;
        }

        public void GameOver()
        {
            Time.timeScale = 0;
            for (int i = 0; i < 4; i++) StopGenerating(i);
            GuangyuanCanvas.Instance.gameOver.gameObject.SetActive(true);
        }

        private void Victory()
        {
            Time.timeScale = 0;
            for (int i = 0; i < 4; i++) StopGenerating(i);
            GuangyuanCanvas.Instance.victory.gameObject.SetActive(true);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(Vector3.zero, innerRadius);
        }
    }
}