using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : MonoBehaviour
{
    private Rigidbody2D rb;

    public Transform left_point, right_point;
    private float left_x, right_x;
    public bool faced_left;//�����ж����������

    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.DetachChildren();//����Ϸ��ʼ��������Һ��ӵ����һ�̣��Ͼ����ӹ�ϵ

        //�����������ֵ�����������������������壬��ֹ�ѻ�
        left_x = left_point.position.x;
        right_x = right_point.position.x;
        Destroy(left_point.gameObject);
        Destroy(right_point.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (faced_left)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            if (transform.position.x < left_x)
            {
                transform.localScale = new Vector3(1, 1, 1);
                faced_left = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            if (transform.position.x > right_x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                faced_left = true;
            }
        }
    }
}
