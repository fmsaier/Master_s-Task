using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;
namespace XLZXLZ
{
    public class TeachPannel : MonoBehaviour
    {
        public GameObject[] gameObjects;
        private int currentIndex = -1;
        private Vector3 initialPosition;
        public float moveDuration = 2f; // 移动持续时间

        [SerializeField]
        private Text ButtonText;

        [SerializeField]
        private ItemGenerator generator;

        [SerializeField]
        private float startHeight = 30;

        void Start()
        {
            initialPosition = transform.position;
            transform.position += Vector3.up * startHeight;
            MoveBack();
        }

        void MoveBack()
        {
            transform.DOMove(initialPosition, moveDuration).SetEase(Ease.OutBack);
        }

        public void Next()
        {
            currentIndex++;
            if (currentIndex >= gameObjects.Length)
            {
                End();
                return;
            }

            // 禁用上一个对象
            if (currentIndex > 0)
            {
                gameObjects[currentIndex - 1].SetActive(false);
            }

            // 启用下一个对象
            gameObjects[currentIndex].SetActive(true);

            if (currentIndex == gameObjects.Length - 1)
            {
                ButtonText.text = "开始游戏";
            }
        }

        public void End()
        {
            transform.DOMove(initialPosition + Vector3.up * startHeight, moveDuration).SetEase(Ease.InBack);
            Score.instance.isStart = true;
            generator.Trigger();
        }
    }
}