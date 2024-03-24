using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Merryfling {
    public class FoodGenerator : MonoBehaviour
    {
        [Header("���ɲ���")]
        public float spawnInterval = 1f;            // ʳ�����ɵļ��ʱ��
        public float spawnHeight = 10f;         // ʳ��������Ϸ������ɾ���
        public Vector2 spawnWeight = new Vector2(-8f, 8f);          // ʳ�����ɵĺ���Χ
        public Vector2 fallSpeedRange = new Vector2(1f, 5f);            // ʳ��������ٶȷ�Χ
        [Header("Ԥ����")]
        public GameObject[] foodPrefabs;            // ʳ��Ԥ��������
        private GameObject currentFood;
        [Header("�����Ϣ")]
        public GameObject player;

        void Start()
        {
            StartCoroutine(SpawnFoodRoutine());
        }

        IEnumerator SpawnFoodRoutine()
        {
            while (player)
            {
                SpawnFood();
                Debug.Log("����");
                yield return new WaitForSeconds(spawnInterval);
            }
        }

        void SpawnFood()
        {
            Vector3 spawnPos = new Vector3(player.transform.position.x + Random.Range(spawnWeight.x, spawnWeight.y), player.transform.position.y + spawnHeight, -1);// ��ҵĵ�ǰλ�ü���һ���̶��߶���Ϊ����λ��

            currentFood = Instantiate(foodPrefabs[Random.Range(0, foodPrefabs.Length)], spawnPos, Quaternion.identity);

            Rigidbody2D rb = currentFood.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0, -Random.Range(fallSpeedRange.x, fallSpeedRange.y));
        }
    }
}
