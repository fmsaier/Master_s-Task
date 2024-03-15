using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBianque : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;

    [Header("地面检测")]
    public bool isGround;
    public LayerMask ground;

    [Header("速度")]
    public float speed;

    [Header("对话框")]
    public GameObject Dialog_Guoguo_1;
    public GameObject Dialog_ziyang;
    public GameObject Dialog_zibao;
    public GameObject Dialog_zhaojianzi_select;
    public GameObject Dialog_qihuanhou;
    public GameObject Dialog_Qi_afterMoveOff;
    public GameObject Dialog_Lingwu;

    [Header("场景切换")]
    public string sceneFrom;
    public string sceneTogo;

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
        isGround = false;
        if (coll.IsTouchingLayers(ground))
        {
            isGround = true;
        }
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
        if (Handle != null)
        {
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
    }

    //动画效果
    void SwitchAnim()
    {
        if (isGround)
        {
            anim.SetBool("Idle", true);
        }
    }

    //碰撞触发器
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "gateGuoguo")
        {
            Time.timeScale = 0f;
            Dialog_Guoguo_1.SetActive(true);
        }
        if (collision.tag == "gateWeiguo")
        {
            StartCoroutine(TransitionToScene(sceneFrom, sceneTogo));
        }
        if (collision.tag == "Ziyang")
        {
            Time.timeScale = 0f;
            Dialog_ziyang.SetActive(true);
        }
        if (collision.tag == "Zibao")
        {
            Time.timeScale = 0f;
            Dialog_zibao.SetActive(true);
        }
        if (collision.tag == "Zhaojianzi")
        {
            Time.timeScale = 0f;
            Dialog_zhaojianzi_select.SetActive(true);
        }
        if (collision.tag == "Qihuanhou")
        {
            Time.timeScale = 0f;
            Dialog_qihuanhou.SetActive(true);
        }
        if (collision.tag == "QiGate")
        {
            Time.timeScale = 0f;
            Dialog_Qi_afterMoveOff.SetActive(true);
        }
        if (collision.tag == "Lingwu")
        {
            if (Dialog_Lingwu != null)
            {
                Dialog_Lingwu.SetActive(true);
            }
        }
    }
    //离开触发器
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Lingwu")
        {
            if (Dialog_Lingwu != null)
            {
                Dialog_Lingwu.SetActive(false);
            }
        }
    }
        // 协程方法
        private IEnumerator TransitionToScene(string from, string to)
    {
        yield return SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive); // 以激活的方式加载场景
        // 设置新场景为激活场景
        // 此时场景中一共有两个场景，序号为0与1，通过数量-1从而找到新加载的场景
        Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(newScene);
        yield return SceneManager.UnloadSceneAsync(from); // 卸载场景      
    }
}
