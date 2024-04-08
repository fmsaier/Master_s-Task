using UnityEngine;
using SqR;

public class Player : MonoBehaviour
{
    public float ySpeed = 1f; // 固定的 y 轴向上速度
    public float k = 1f; // 乘以 SqrValue 的系数

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