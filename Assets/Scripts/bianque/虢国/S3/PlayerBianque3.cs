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

    [Header("�����л�")]
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

    [Header("������")]
    public GameObject Handle;

    void Movement()
    {
        /*�޶�*/
        if (Handle != null)
        {
            float posX = Handle.transform.localPosition.x;  //��ȡ Handle ����ı��� X ����ֵ
            float horizontal_move = posX / 128f;  //ģ�� Input.GetAxis �ķ���ֵ

            float faced_direction;
            if (posX > 0)
            {
                faced_direction = 1;  //ģ�� Input.GetAxisRaw ���� 1
            }
            else if (posX < 0)
            {
                faced_direction = -1;  //ģ�� Input.GetAxisRaw ���� -1
            }
            else
            {
                faced_direction = 0;  //ģ�� Input.GetAxisRaw ���� 0
            }

            //��ɫ�ƶ�
            rb.velocity = new Vector2(horizontal_move * speed * Time.fixedDeltaTime, rb.velocity.y);
            anim.SetFloat("Walking", Mathf.Abs(faced_direction));
            //��ɫ����
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
            /*�޶�����*/
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
        //��ײ��
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
    // Э�̷���
    private IEnumerator TransitionToScene(string from, string to)
    {
        yield return SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive); // �Լ���ķ�ʽ���س���
        // �����³���Ϊ�����
        // ��ʱ������һ�����������������Ϊ0��1��ͨ������-1�Ӷ��ҵ��¼��صĳ���
        Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(newScene);
        yield return SceneManager.UnloadSceneAsync(from); // ж�س���      
    }
}
