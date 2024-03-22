using UnityEngine;
using Unity.VisualScripting;
using System.Collections;

namespace XLZXLZ
{
    public class ItemGenerator : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] Items;
        [SerializeField]
        private float minDelay, maxDelay;
        [SerializeField]
        private Transform boundaryTopLeft, boundaryBottomRight;

        private void Start()
        {
            Score.instance.onEnd += (() => { StopAllCoroutines(); });
        }

        public void Trigger()
        {
            StartCoroutine(GenerateItem());
        }

        private IEnumerator GenerateItem()
        {
            while (true)
            {
                float delay = Random.Range(minDelay, maxDelay);
                yield return new WaitForSeconds(delay);

                // 随机选择一个位置在边界内生成item
                Vector3 randomPosition = new Vector3(Random.Range(boundaryTopLeft.position.x, boundaryBottomRight.position.x),
                                                     Random.Range(boundaryBottomRight.position.y, boundaryTopLeft.position.y),
                                                     0f);

                GameObject itemToSpawn = Items[Random.Range(0, Items.Length)];
                Instantiate(itemToSpawn, randomPosition, Quaternion.identity,transform);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(boundaryTopLeft.position, new Vector3(boundaryBottomRight.position.x, boundaryTopLeft.position.y, 0f));
            Gizmos.DrawLine(boundaryTopLeft.position, new Vector3(boundaryTopLeft.position.x, boundaryBottomRight.position.y, 0f));
            Gizmos.DrawLine(boundaryBottomRight.position, new Vector3(boundaryTopLeft.position.x, boundaryBottomRight.position.y, 0f));
            Gizmos.DrawLine(boundaryBottomRight.position, new Vector3(boundaryBottomRight.position.x, boundaryTopLeft.position.y, 0f));
        }
    }
}