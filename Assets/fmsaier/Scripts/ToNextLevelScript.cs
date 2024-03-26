using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//创建人： Trigger 
//功能说明：通向第二关的剧情
//***************************************** 
public class ToNextLevelScript : MonoBehaviour
{
    private float speed;
    private Vector3 targetPos;
    private bool startMove;
    private Rigidbody2D rigid2D;
    private Animator animator;

    void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        speed = 2;
        animator = GameObject.Find("Gris").GetComponent<Animator>();
    }

    private void Start()
    {
        GetComponent<SpriteRenderer>().flipX = true;
    }

    void FixedUpdate()
    {
        if (startMove)
        {
            if (Vector2.Distance(transform.position, targetPos) > 0.01f)
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.fixedDeltaTime);
            }
            else
            {
                startMove = false;
            }
        }
        
    }
    /// <summary>
    /// 开始移动方法
    /// </summary>
    /// <param name="pos">目标位置</param>
    public void StartMove(Vector3 pos)
    {
        startMove = true;
        targetPos = pos;
    }
    /// <summary>
    /// 设置刚体类型
    /// </summary>
    /// <param name="rigidbodyType2D">类型</param>
    public void SetRigidBodyType(RigidbodyType2D rigidbodyType2D)
    {
        rigid2D.bodyType = rigidbodyType2D;
    }

    /// <summary>
    /// 让Girs播放相关状态动画
    /// </summary>
    /// <param name="stateName"></param>
    public void PlayAnimation(string stateName)
    {
        animator.Play(stateName);
    }
}
