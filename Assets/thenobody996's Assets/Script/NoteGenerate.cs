using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Thenobody
{
    public class NoteGenerate : MonoBehaviour
    {
        public GameObject Canvas;
        RectTransform RectTransform;
        public float frequency;
        public float leftEdge, rightEdge;
        public float height, speed;
        public GameObject[] note;
        public List<Vector3> generatePoints;

        private int track;

        private void Start()
        {
            RectTransform = Canvas.GetComponent<RectTransform>();
            leftEdge = Canvas.transform.position.x - RectTransform.rect.width * 0.4f;
            rightEdge = Canvas.transform.position.x + RectTransform.rect.width * 0.4f;
            height = Canvas.transform.position.y + RectTransform.rect.height * 0.5f;
            for (int i = 1; i <= 7; i++)
            {
                float x = leftEdge + i * RectTransform.rect.width / 8;
                float y = height;
                generatePoints.Add(new Vector3(x, y, 0));
            }
            StartCoroutine(GenerateNotes());
        }
       private IEnumerator GenerateNotes()
        {
            yield return new WaitForSeconds(2);

            for(int rng = Random.Range(1,9); ; rng = Random.Range(1, 9))
            {
                track = Random.Range(0,6);
                switch(rng)
                {
                    case 1:
                        GameObject a = Instantiate(note[1], generatePoints[track], Quaternion.identity);
                        a.transform.SetParent(Canvas.transform);
                        break;
                    case 2:
                        GameObject b = Instantiate(note[2], generatePoints[track], Quaternion.identity);
                        b.transform.SetParent(Canvas.transform);
                        break;
                    case 3:
                        GameObject c = Instantiate(note[3], generatePoints[track], Quaternion.identity);
                        c.transform.SetParent(Canvas.transform);
                        break;
                    case 4:
                        GameObject d = Instantiate(note[4], generatePoints[track], Quaternion.identity);
                        d.transform.SetParent(Canvas.transform);
                        break;
                    default:
                        GameObject e = Instantiate(note[0], generatePoints[track], Quaternion.identity);
                        e.transform.SetParent(Canvas.transform);
                        break;
                }
                yield return new WaitForSeconds(Random.Range(0.8f * frequency, 1.2f * frequency));
            }
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position,new Vector3(100,100,100));
        }
    }
}
