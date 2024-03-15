using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Bowuguan : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;

    [Header("速度")]
    public float speed;

    [Header("对话框")]
    public GameObject Question_Bianque;
    public GameObject Question_Qianyi;
    public GameObject Question_Huatuo;
    public GameObject Question_Lishizhen;
    public GameObject Question_Sunsimiao;
    public GameObject Question_Dongfeng;
    public GameObject Question_Zhangzhongjing;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        GroundMovement();
        SwitchAnim();
    }

    [Header("控制器")]
    public GameObject Handle;

    void GroundMovement()
    {
        //float horizontal_move = Input.GetAxis("Horizontal");
        //float faced_direction = Input.GetAxisRaw("Horizontal");

        /*修订*/
        float posX = Handle.transform.localPosition.x; //获取 Handle 对象的本地 X 坐标值
        float horizontal_move = posX / 128f; //模拟 Input.GetAxis 的返回值

        float faced_direction;
        if (posX > 0)
        {
            faced_direction = 1; //模拟 Input.GetAxisRaw 返回 1
        }
        else if (posX < 0)
        {
            faced_direction = -1; //模拟 Input.GetAxisRaw 返回 -1
        }
        else
        {
            faced_direction = 0; //模拟 Input.GetAxisRaw 返回 0
        }
        /*修订结束*/

        //角色移动
        rb.velocity = new Vector2(horizontal_move * speed * Time.fixedDeltaTime, rb.velocity.y);
        anim.SetFloat("Walking", Mathf.Abs(faced_direction));
        //角色面向
        if (faced_direction != 0)
        {
            transform.localScale = new Vector3(faced_direction, 1, 1);
        }
    }

    //动画效果
    void SwitchAnim()
    {
        anim.SetBool("Idle", true);
 
    }

    //碰撞触发器
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ImageBianque")
        {
            Question_Bianque.SetActive(true);
        }
        if (collision.tag == "ImageQianyi")
        {
            Question_Qianyi.SetActive(true);
        }
        if (collision.tag == "ImageHuatuo")
        {
            Question_Huatuo.SetActive(true);
        }
        if (collision.tag == "ImageLishizhen")
        {
            Question_Lishizhen.SetActive(true);
        }
        if (collision.tag == "ImageDongfeng")
        {
            Question_Dongfeng.SetActive(true);
        }
        if (collision.tag == "ImageZhangzhongjing")
        {
            Question_Zhangzhongjing.SetActive(true);
        }
        if (collision.tag == "ImageSunsimiao")
        {
            Question_Sunsimiao.SetActive(true);
        }
    }

    //离开触发器
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "ImageBianque")
        {
            Question_Bianque.SetActive(false);
        }
        if (collision.tag == "ImageQianyi")
        {
            Question_Qianyi.SetActive(false);
        }
        if (collision.tag == "ImageHuatuo")
        {
            Question_Huatuo.SetActive(false);
        }
        if (collision.tag == "ImageLishizhen")
        {
            Question_Lishizhen.SetActive(false);
        }
        if (collision.tag == "ImageDongfeng")
        {
            Question_Dongfeng.SetActive(false);
        }
        if (collision.tag == "ImageZhangzhongjing")
        {
            Question_Zhangzhongjing.SetActive(false);
        }
        if (collision.tag == "ImageSunsimiao")
        {
            Question_Sunsimiao.SetActive(false);
        }
    }

    //重置游戏
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
