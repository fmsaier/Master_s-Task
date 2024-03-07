using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerQianyi_2 : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;
    public float speed;
    public AudioSource collectionAu;
    private int count;
    private Animator anim;

    [Header("ͼ��")]
    public GameObject iconXin;
    public GameObject iconGan;
    public GameObject iconPi;
    public GameObject iconFei;
    public GameObject iconShen;

    [Header("�����л�")]
    public string sceneFrom;
    public string sceneTogo;

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

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        SwitchAnimation();   
    }

    void SwitchAnimation()
    {
        if (count == 1)
        {
            anim.SetBool("Nanshou", true);
        }
        else if (count == 2)
        {
            anim.SetBool("Yun", true);
        }
        else if (count == 3)
        {
            anim.SetBool("Weixiao", true);
        }
        else if (count == 4)
        {
            anim.SetBool("Xiao", true);
        }
        else if (count == 5)
        {
            count++;
            StartCoroutine(TransitionToScene(sceneFrom, sceneTogo));
        }
    }

    void Movement()
    {
        //���ҷ�����ƶ�
        float horizontalmove; //������ʾ����
        horizontalmove = Input.GetAxis("Horizontal");
        if (horizontalmove != 0)
        {
            rb.velocity = new Vector2(horizontalmove * speed, rb.velocity.y);
        }

        float verticalmove;
        verticalmove = Input.GetAxis("Vertical");
        if (verticalmove != 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, verticalmove * speed);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Xin")
        {
            collectionAu.Play();
            iconXin.SetActive(false);
            Destroy(collision.gameObject);
            count++;
        }
        if (collision.tag == "Gan")
        {
            collectionAu.Play();
            iconGan.SetActive(false);
            Destroy(collision.gameObject);
            count++;
        }
        if (collision.tag == "Pi")
        {
            collectionAu.Play();
            iconPi.SetActive(false);
            Destroy(collision.gameObject);
            count++;
        }
        if (collision.tag == "Fei")
        {
            collectionAu.Play();
            iconFei.SetActive(false);
            Destroy(collision.gameObject);
            count++;
        }
        if (collision.tag == "Shen")
        {
            collectionAu.Play();
            iconShen.SetActive(false);
            Destroy(collision.gameObject);
            count++;
        }
    }
}
