using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Player : MonoBehaviour
{
    [Header("摇杆的杆子")]
    public GameObject Handle;


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
        ATKCD -= Time.deltaTime;
        if (ATKCD <= 0f)
        {
            ATKCD = 0f;
        }
        if (!isDeath)
        {
            Movement();
            //Run();
            //Attack();
            //Filp();
            //Jump();
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
                jumpChance = 1;
                myAnim.SetBool("Jump", false);
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

    public void Jump()
    {
        if (!isDeath)
        {
            if (jumpChance == 1)
            {
                myAnim.SetBool("Stay", false);
                myAnim.SetBool("Jump", true);
                jumpChance--;
                Vector2 jumpVel = new Vector2(0.0f, jumpSpeed);
                myRb2D.velocity = jumpVel * Vector2.up;
                SoundsManager_R.Instance_RS.SfxPlay("Jump");
            }

        }
        if (jumpChance == 0)
        {
            if (myRb2D.velocity.y <= 0.0f)
            {
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

    public void Attack()
    {
        
        if (!isDeath)
        {
            myAnim.SetTrigger("Attack");
            myAnim.SetBool("isAttack", true);
            if (ATKCD <= 0f)
            {
                GameObject b;
                b = Instantiate(Bullet, gameObject.transform.position, Quaternion.identity);
                SoundsManager_R.Instance_RS.SfxPlay("ATK");
                Rigidbody2D br;
                br = b.GetComponent<Rigidbody2D>();
                br.velocity = transform.rotation * new Vector3(shootSpeed, 0, 0);
                ATKCD = 0.3f;
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

    void Movement()
    {
        if (Handle != null)
        {
            /* X方向 */
            float posX = Handle.transform.localPosition.x; //获取 Handle 对象的 X 坐标值。
            float horizontal_move = posX / 128f; //模拟 Input.GetAxis 的返回值。
            float faced_x;
            if (posX > 0)
            {
                faced_x = 1; //模拟 Input.GetAxisRaw 返回 1 。
                //Debug.Log("1");
            }
            else if (posX < 0)
            {
                faced_x = -1; //模拟 Input.GetAxisRaw 返回 -1 。
                //Debug.Log("-1");
            }
            else
            {
                faced_x = 0; //模拟 Input.GetAxisRaw 返回 0 。
            }
            //Debug.Log(horizontal_move);
            myRb2D.velocity = new Vector2(horizontal_move * runSpeed,myRb2D.velocity.y); //X方向移动。
            bool playerXAxisSpeed = Mathf.Abs(myRb2D.velocity.x) > Mathf.Epsilon;
            myAnim.SetBool("Run", playerXAxisSpeed);
            if (faced_x != 0) //角色面向，即X方向旋转物体的代码。
            {
                transform.localScale = new Vector3(faced_x, 1, 1);
            }
        }
    }
}