using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerBianque3 : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;
    private Animator anim;
    public float speed;
    public AudioSource yaocaiAu;
    private int count;

    [Header("场景切换")]
    public string sceneFrom;
    public string sceneTogo;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    [Header("控制器")]
    public GameObject Handle;

    void Movement()
    {
        /*修订*/
        if (Handle != null)
        {
            float posX = Handle.transform.localPosition.x;  //获取 Handle 对象的本地 X 坐标值
            float horizontal_move = posX / 128f;  //模拟 Input.GetAxis 的返回值

            float faced_direction;
            if (posX > 0)
            {
                faced_direction = 1;  //模拟 Input.GetAxisRaw 返回 1
            }
            else if (posX < 0)
            {
                faced_direction = -1;  //模拟 Input.GetAxisRaw 返回 -1
            }
            else
            {
                faced_direction = 0;  //模拟 Input.GetAxisRaw 返回 0
            }

            //角色移动
            rb.velocity = new Vector2(horizontal_move * speed * Time.fixedDeltaTime, rb.velocity.y);
            anim.SetFloat("Walking", Mathf.Abs(faced_direction));
            //角色面向
            if (faced_direction != 0)
            {
                transform.localScale = new Vector3(faced_direction, 1, 1);
            }

            float posY = Handle.transform.localPosition.y;
            float vertical_move = posY / 128f;

            float verticalSpeed;
            if (posY != 0)
            {
                verticalSpeed = 1;
            }
            else
            {
                verticalSpeed = 0;
            }

            anim.SetFloat("Walking", Mathf.Abs(verticalSpeed));
            rb.velocity = new Vector2(rb.velocity.x, vertical_move * speed * Time.fixedDeltaTime);
            /*修订结束*/
        }
        //float horizontal_move = Input.GetAxis("Horizontal");
        //float faced_direction = Input.GetAxisRaw("Horizontal");

        //float vertical_move = Input.GetAxis("Vertical");
        //float verticalSpeed = Input.GetAxisRaw("Vertical");
        //if (vertical_move != 0)
        //{
        //    anim.SetFloat("Walking", Mathf.Abs(verticalSpeed));
        //    rb.velocity = new Vector2(rb.velocity.x, vertical_move * speed * Time.fixedDeltaTime);
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //碰撞门
        if (collision.tag == "Yaocai")
        {
            yaocaiAu.Play();
            Destroy(collision.gameObject);
            if (count == 4)
            {
                StartCoroutine(TransitionToScene(sceneFrom, sceneTogo));
            }
            else
            {
                count++;
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
