using Dawnize;
using UnityEngine;

namespace Merryfling
{
    public class BackgroundLooper : MonoBehaviour
    {
        [Header("�����������")]
        public float speed = 5f; // ���������ٶ�
        private GameObject[] backgrounds; // ����ͼƬ����
        private float backgroundWidth; // ��������ͼƬ�Ŀ��

        void Start()
        {
            // ��ʼ���������鲢��ȡ�������
            backgrounds = new GameObject[transform.childCount];
            for (int i = 0; i < transform.childCount; i++)
            {
                backgrounds[i] = transform.GetChild(i).gameObject;
            }
            backgroundWidth = backgrounds[0].GetComponent<SpriteRenderer>().bounds.size.x;
        }

        void Update()
        {
            // �����ƶ�����
            foreach (GameObject bg in backgrounds)
            {
                bg.transform.Translate(Vector2.right * speed * Time.deltaTime);
            }

            // ����Ƿ��б�����Ҫ�����¶�λ
            foreach (GameObject bg in backgrounds)
            {
                if (bg.transform.localPosition.x >= backgroundWidth * 1.5f)
                {
                    // �������ƶ��������
                    float shiftLeft = backgroundWidth * backgrounds.Length;
                    bg.transform.localPosition -= new Vector3(shiftLeft, 0, 0);
                }
            }
        }
    }
}