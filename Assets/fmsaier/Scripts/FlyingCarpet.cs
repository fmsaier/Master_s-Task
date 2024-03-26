using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//创建人： Trigger 
//功能说明：飞毯
//***************************************** 
public class FlyingCarpet : MonoBehaviour
{
    private bool moveDir;
    private float lerpSpeed;
    private Vector2 startPoint;
    private Vector2 endPoint;
    private SpriteRenderer sr;

    void Start()
    {
        lerpSpeed = 3;
        sr = GetComponent<SpriteRenderer>();
        startPoint = GameObject.Find("FlyingStartPoint").transform.localPosition;
        endPoint = GameObject.Find("EndPoint").transform.localPosition;
        moveDir = true;
        sr.flipX = true;
    }

    void FixedUpdate()
    {
        if (moveDir)//从起点到终点
        {
            transform.localPosition = Vector2.MoveTowards(transform.localPosition,endPoint,lerpSpeed*Time.fixedDeltaTime);
            if (Vector2.Distance(transform.localPosition,endPoint)<=0.1f)
            {
                sr.flipX = false;
                moveDir = false;
            }
        }
        else
        {
            transform.localPosition = Vector2.MoveTowards(transform.localPosition, startPoint, lerpSpeed * Time.fixedDeltaTime);
            if (Vector2.Distance(transform.localPosition, startPoint) <= 0.1f)
            {
                sr.flipX = true;
                moveDir = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name=="Gris")
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.name == "Gris")
        {
            collision.transform.SetParent(null);
        }
    }
}
