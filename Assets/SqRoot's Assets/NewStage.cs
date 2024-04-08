using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SqR;

public class NewStage : MonoBehaviour
{
    public bool isStage;
    public GameObject[] objects;

    public float leftRange;
    public float rightRange;

    private Vector3 v;

    private void Start()
    {
        v = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            float r = Random.Range(leftRange, rightRange);
            Vector3 newPosition = new Vector3(v.x + r, v.y, v.z);
            int randomIndex = Random.Range(0, objects.Length);
            GameObject randomObject = objects[randomIndex];
            Instantiate(randomObject, newPosition, Quaternion.identity);
            Destroy(gameObject);
            if (isStage)
                SqR.LongPress.StageNum++;
        }
    }
}
