using UnityEngine;
using SqR;

public class Player : MonoBehaviour
{
    public float ySpeed = 1f; // �̶��� y �������ٶ�
    public float k = 1f; // ���� SqrValue ��ϵ��

    private Rigidbody2D rb;
    private float xSpeed;

    void Update()
    {
        if (SqR.LongPress.SqrValue != 0f)
        {
            SqR.LongPress.IsJump = true;
            rb = GetComponent<Rigidbody2D>();
            xSpeed = SqR.LongPress.SqrValue * k;
            rb.velocity = new Vector3(xSpeed, ySpeed);

            SqR.LongPress.SqrValue = 0f;
        }
    }
}