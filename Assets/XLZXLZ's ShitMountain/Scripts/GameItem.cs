using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace XLZXLZ
{
    public class GameItem : MonoBehaviour
    {
        public float minLiveTime = 4, maxLiveTime = 6;

        public float score;
        public GameObject particle;
        public float clickEffectDuration = 0.5f;

        private Button button;
        private float rotateSpeed;

        private void Start()
        {
            var s = transform.localScale.x;
            transform.localScale = Vector3.zero;
            DOTween.Sequence()
                .Append(transform.DOScale(Vector3.one * s, 1f).SetEase(Ease.OutBack))
                .AppendInterval(Random.Range(minLiveTime, maxLiveTime))
                .Append(transform.DOScale(Vector3.zero, .5f).SetEase(Ease.OutQuad))
                .OnComplete(() => Destroy(gameObject));



            // 将按钮点击事件绑定到OnClick方法
            button = GetComponent<Button>();
            button.onClick.AddListener(OnClick);

            rotateSpeed = Random.Range(15, 60);
        }

        private void OnClick()
        {
            // 立刻摧毁自身
            Destroy(gameObject);
            Instantiate(particle, transform.position, particle.transform.rotation);

            Score.instance.UpdateScore(score);
            // 执行其他逻辑
        }

        private void Update()
        {
            transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        }

        public void Debug()
        {
            print("!");
        }
    }
}