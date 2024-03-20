using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuki
{
    public class EnemyGenerator : MonoBehaviour
    {
        public GameObject[] enemy;
        public float coldDown;
        public Vector2 generatorCenter;
        public Vector2 generatorSize;
        private Vector2 generatorFix;

        private void Start()
        {
            StartCoroutine(GenerateEnemy());
        }

        private IEnumerator GenerateEnemy()
        {
            yield return new WaitForSeconds(5);

            for(int rng = Random.Range(1, 6); ; rng = Random.Range(1, 6))
            {
                generatorFix = new Vector2(Random.Range(-generatorSize.x / 2, generatorSize.x / 2), Random.Range(-generatorSize.y / 2, generatorSize.y / 2));

                switch (rng)
                {
                    case 1:
                        Instantiate(enemy[1], generatorCenter + generatorFix, Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(enemy[2], generatorCenter + generatorFix, Quaternion.identity);
                        break;
                    default:
                        Instantiate(enemy[0], generatorCenter + generatorFix, Quaternion.identity);
                        break;
                }

                yield return new WaitForSeconds(coldDown);
            }
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(generatorCenter, generatorSize);
        }
    }
}

