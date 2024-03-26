using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//*****************************************
//创建人： Trigger 
//功能说明：Gris的控制脚本
//***************************************** 
public class Gris : MonoBehaviour
{
    private float moveFactor;
    private float speed;
    private Rigidbody2D rigid2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    [HideInInspector]
    public float jumpForce;
    public bool isGrounded;
    private AudioClip jumpClip;
    public float timeVal;
    private float timer;
    private AudioClip moveClip;
    private bool lastIsGrounded;
    private AudioClip landClip;
    private Song song;
    public List<TearPet> tearList;
    public bool isDead;
    public bool cancelMove;

    void Start()
    {
        speed = 5;
        rigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isGrounded = true;
        jumpForce = 2500;
        jumpClip = Resources.Load<AudioClip>("Gris/Audioclips/Jump");
        moveClip = Resources.Load<AudioClip>("Gris/Audioclips/Move");
        landClip= Resources.Load<AudioClip>("Gris/Audioclips/Land");
        lastIsGrounded= isGrounded = true;
        song = GetComponentInChildren<Song>();
        tearList = new List<TearPet>();
    }

    void Update()
    {
        if (isDead)
        {
            return;
        }

        if (song!=null)
        {
            if (Input.GetKey(KeyCode.K)&&song.StopSinging)
            {
                song.SetSingingState(true);
                moveFactor = 0;
                animator.SetBool("Sing",true);
                return;
            }
            else
            {
                if (Input.GetKeyUp(KeyCode.K))
                {
                    song.StopSinging=false;
                }
                song.SetSingingState(false);
                animator.SetBool("Sing", false);
            }
        }      
        moveFactor = Input.GetAxisRaw("Horizontal");
        //防止进入通关检测区域时，玩家一直按方向键移动
        if (cancelMove)
        {
            moveFactor = 0;
        }


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rigid2D.AddForce(Vector2.up * jumpForce);
            isGrounded = false;
            lastIsGrounded = isGrounded;
            AudioSource.PlayClipAtPoint(jumpClip, transform.position);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 2;
            timeVal = 1f;
            animator.SetBool("Walk", true);
        }
        else
        {
            speed = 5;
            timeVal = 0.5f;
            animator.SetBool("Walk", false);
        }
    }

    private void FixedUpdate()
    {
        if (isDead)
        {
            moveFactor = 0;
            return;
        }
        //速度小于0，处于在高空的状态
        if (rigid2D.velocity.y <= -5f && rigid2D.velocity.y >= -7)
        {
            isGrounded = false;
            lastIsGrounded = isGrounded;
        }
        Move();
    }

    private void Move()
    {
        animator.SetBool("IsGrounded", isGrounded);
        if (moveFactor > 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveFactor < 0)
        {
            spriteRenderer.flipX = false;
        }
        if (Mathf.Abs(moveFactor) > 0 && isGrounded)
        {
            if (timer >= timeVal)
            {
                timer = 0;
                AudioSource.PlayClipAtPoint(moveClip, transform.position);
            }
            else
            {
                timer += Time.fixedDeltaTime;
            }
        }
        else
        {
            timer = 0;
        }
        Vector2 moveDirection = Vector2.right * moveFactor;
        Vector2 moveVelocity = moveDirection * speed;
        Vector2 jumpVelocity = new Vector2(0, rigid2D.velocity.y);
        animator.SetFloat("MoveY", rigid2D.velocity.y);
        rigid2D.velocity = moveVelocity + jumpVelocity;
        animator.SetFloat("MoveX", Mathf.Abs(rigid2D.velocity.x));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //当前碰到了游戏物体，并且是地面       
        if (collision.collider.ClosestPoint(transform.position).y < transform.position.y)
        {
            isGrounded = collision.gameObject.CompareTag("Ground");
            if (isGrounded!=lastIsGrounded)
            {
                if (isGrounded)
                {
                    AudioSource.PlayClipAtPoint(landClip,transform.position);
                }
            }
            lastIsGrounded = isGrounded;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name== "BossSong")
        {
            if (tearList.Count>0)
            {
                Destroy(tearList[tearList.Count-1].gameObject);
                tearList.RemoveAt(tearList.Count-1);
            }
            else
            {
                animator.Play("Cry");
                isDead = true;
                Invoke("LoadScene", 2);
            }
        }
        
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(1);
    }

    public void PlaySingAnimation()
    {
        animator.SetBool("Sing", true);
        isDead = true;
        song.SetSingingState(false);
    }
}
