using Dawnize;
using UnityEngine;

namespace Merryfling
{
    public class BackgroundLooper : MonoBehaviour
    {
        [Header("背景滚动相关")]
        public float speed = 5f; // 背景滚动速度
        private GameObject[] backgrounds; // 背景图片数组
        private float backgroundWidth; // 单个背景图片的宽度

        void Start()
        {
            // 初始化背景数组并获取背景宽度
            backgrounds = new GameObject[transform.childCount];
            for (int i = 0; i < transform.childCount; i++)
            {
                backgrounds[i] = transform.GetChild(i).gameObject;
            }
            backgroundWidth = backgrounds[0].GetComponent<SpriteRenderer>().bounds.size.x;
        }

        void Update()
        {
            // 向右移动背景
            foreach (GameObject bg in backgrounds)
            {
                bg.transform.Translate(Vector2.right * speed * Time.deltaTime);
            }

            // 检查是否有背景需要被重新定位
            foreach (GameObject bg in backgrounds)
            {
                if (bg.transform.localPosition.x >= backgroundWidth * 1.5f)
                {
                    // 将背景移动到最左侧
                    float shiftLeft = backgroundWidth * backgrounds.Length;
                    bg.transform.localPosition -= new Vector3(shiftLeft, 0, 0);
                }
            }
        }
    }
}