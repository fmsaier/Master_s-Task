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

    void Movement()
    {
        float horizontal_move = Input.GetAxis("Horizontal");
        float faced_direction = Input.GetAxisRaw("Horizontal");
        //��ɫ�ƶ�
        rb.velocity = new Vector2(horizontal_move * speed * Time.fixedDeltaTime, rb.velocity.y);
        anim.SetFloat("Walking", Mathf.Abs(faced_direction));
        //��ɫ����
        if (faced_direction != 0)
        {
            transform.localScale = new Vector3(faced_direction, 1, 1);
        }

        float verticalmove;
        verticalmove = Input.GetAxis("Vertical");
        float verticalSpeed = Input.GetAxisRaw("Vertical");
        if (verticalmove != 0)
        {
            anim.SetFloat("Walking", Mathf.Abs(verticalSpeed));
            rb.velocity = new Vector2(rb.velocity.x, verticalmove * speed * Time.fixedDeltaTime);
        }
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
