using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Player : MonoBehaviour
{
    public GameObject Bullet;
    [SerializeField] private float shootSpeed;

    float ATKCD = 0.5f;

    public float runSpeed;
    public float jumpSpeed;
    public float jumpChance;
    private Rigidbody2D myRb2D;
    private BoxCollider2D myFeet;
    private Animator myAnim;
    private TrailRenderer myTrail;
    private bool isGround;




    private bool isOneSide;

    public bool isDeath = false;
    void Start()
    {
        myRb2D = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        myFeet = GetComponent<BoxCollider2D>();
        myTrail = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDeath)
        {
            Run();
            Attack();
            Filp();
            Jump();
            CheckGround();
            oneSideCheck();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") && jumpChance == 1)
        {
            if (myRb2D.velocity.y <= 0.1f)
            {
                myAnim.SetBool("Jump", false);
                myAnim.SetBool("Fall", false);
                CheckGround();
            }
        }
    }

    void Filp()
    {
        bool playerXAxisSpeed = Mathf.Abs(myRb2D.velocity.x) > Mathf.Epsilon;
        if (playerXAxisSpeed)
        {
            if (myRb2D.velocity.x > 0.1f)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            if (myRb2D.velocity.x < -0.1f)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }

    void CheckGround()
    {
        isGround = myFeet.IsTouchingLayers(LayerMask.GetMask("Ground")) || myFeet.IsTouchingLayers(LayerMask.GetMask("oneSideBoard")) || myFeet.IsTouchingLayers(LayerMask.GetMask("breakWall"));
        isOneSide = myFeet.IsTouchingLayers(LayerMask.GetMask("oneSideBoard"));
        if (isGround)
        {
            if (myRb2D.velocity.y <= 0.1f)
            {
                jumpChance = 2;
                myAnim.SetBool("Jump", false);
                myAnim.SetBool("HighJump", false);
                myAnim.SetBool("Fall", false);
                myAnim.SetBool("Stay", true);
            }

        }
    }

    void Run()
    {
        float moveDir = Input.GetAxis("Horizontal");
        Vector2 playerVel = new Vector2(moveDir * runSpeed, myRb2D.velocity.y);
        myRb2D.velocity = playerVel;
        bool playerXAxisSpeed = Mathf.Abs(myRb2D.velocity.x) > Mathf.Epsilon;
        myAnim.SetBool("Run", playerXAxisSpeed);
        //soundsManager.Instance.SfxPlay("Run");
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (jumpChance == 2)
            {
                myAnim.SetBool("Stay", false);
                myAnim.SetBool("Jump", true);
                isGround = false;
                jumpChance--;
                Vector2 jumpVel = new Vector2(0.0f, jumpSpeed);
                myRb2D.velocity = jumpVel * Vector2.up;
                //soundsManager.Instance.SfxPlay("Jump");
            }
            else if (jumpChance == 1)
            {
                myAnim.SetBool("Jump", true);
                myAnim.SetBool("HighJump", true);
                jumpChance--;
                Vector2 jumpVel = new Vector2(0.0f, jumpSpeed);
                myRb2D.velocity = jumpVel * Vector2.up;
                //soundsManager.Instance.SfxPlay("Jump");
            }

        }
        if (jumpChance == 0)
        {
            if (myRb2D.velocity.y <= 0.0f)
            {
                myAnim.SetBool("HighJump", false);
                myAnim.SetBool("Jump", false);
                myAnim.SetBool("Fall", true);
            }
        }
        if (jumpChance == 1)
        {
            if (myRb2D.velocity.y <= 0.0f)
            {
                myAnim.SetBool("Jump", false);
                myAnim.SetBool("Fall", true);
            }
        }


    }

    void Attack()
    {
        ATKCD -= Time.deltaTime;
        if (ATKCD <= 0f)
        {
            ATKCD = 0f;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            myAnim.SetTrigger("Attack");
            myAnim.SetBool("isAttack", true);
            if(ATKCD <= 0f)
            {
                GameObject b;
                b = Instantiate(Bullet, gameObject.transform.position, Quaternion.identity);
                Rigidbody2D br;
                br = b.GetComponent<Rigidbody2D>();
                br.velocity = transform.rotation * new Vector3(shootSpeed, 0, 0);
                ATKCD = 0.5f;
            }

        }
    }

    void oneSideCheck()
    {
        if (isGround && gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
        }
        float VecY = Input.GetAxis("Vertical");
        if (isOneSide && VecY <= -0.1f)
        {
            gameObject.layer = LayerMask.NameToLayer("oneSideBoard");
            Invoke(nameof(ResortPlayerLayer), 0.4f);
        }
    }

    void ResortPlayerLayer()
    {
        if (!isGround && gameObject.layer != LayerMask.NameToLayer("Player"))
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
        }

    }
}
