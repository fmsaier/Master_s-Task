using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Merryfling {
    public class FoodGenerator : MonoBehaviour
    {
        [Header("生成参数")]
        public float spawnInterval = 1f;            // 食物生成的间隔时间
        public float spawnHeight = 10f;         // 食物在玩家上方的生成距离
        public Vector2 spawnWeight = new Vector2(-8f, 8f);          // 食物生成的横向范围
        public Vector2 fallSpeedRange = new Vector2(1f, 5f);            // 食物下落的速度范围
        [Header("预制体")]
        public GameObject[] foodPrefabs;            // 食物预制体数组
        private GameObject currentFood;
        [Header("玩家信息")]
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
                Debug.Log("生成");
                yield return new WaitForSeconds(spawnInterval);
            }
        }

        void SpawnFood()
        {
            Vector3 spawnPos = new Vector3(player.transform.position.x + Random.Range(spawnWeight.x, spawnWeight.y), player.transform.position.y + spawnHeight, -1);// 玩家的当前位置加上一个固定高度作为生成位置

            currentFood = Instantiate(foodPrefabs[Random.Range(0, foodPrefabs.Length)], spawnPos, Quaternion.identity);

            Rigidbody2D rb = currentFood.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0, -Random.Range(fallSpeedRange.x, fallSpeedRange.y));
        }
    }
}
