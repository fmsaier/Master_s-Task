using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBianque : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;

    [Header("������")]
    public bool isGround;
    public LayerMask ground;

    [Header("�ٶ�")]
    public float speed;

    [Header("�Ի���")]
    public GameObject Dialog_Guoguo_1;
    public GameObject Dialog_ziyang;
    public GameObject Dialog_zibao;
    public GameObject Dialog_zhaojianzi_select;
    public GameObject Dialog_qihuanhou;
    public GameObject Dialog_Qi_afterMoveOff;
    public GameObject Dialog_Lingwu;

    [Header("�����л�")]
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

    [Header("������")]
    public GameObject Handle;

    void GroundMovement()
    {
        //float horizontal_move = Input.GetAxis("Horizontal");
        //float faced_direction = Input.GetAxisRaw("Horizontal");

        /*�޶�*/
        if (Handle != null)
        {
            float posX = Handle.transform.localPosition.x; //��ȡ Handle ����ı��� X ����ֵ
            float horizontal_move = posX / 128f; //ģ�� Input.GetAxis �ķ���ֵ

            float faced_direction;
            if (posX > 0)
            {
                faced_direction = 1; //ģ�� Input.GetAxisRaw ���� 1
            }
            else if (posX < 0)
            {
                faced_direction = -1; //ģ�� Input.GetAxisRaw ���� -1
            }
            else
            {
                faced_direction = 0; //ģ�� Input.GetAxisRaw ���� 0
            }
            /*�޶�����*/

            //��ɫ�ƶ�
            rb.velocity = new Vector2(horizontal_move * speed * Time.fixedDeltaTime, rb.velocity.y);
            anim.SetFloat("Walking", Mathf.Abs(faced_direction));
            //��ɫ����
            if (faced_direction != 0)
            {
                transform.localScale = new Vector3(faced_direction, 1, 1);
            }
        }
    }

    //����Ч��
    void SwitchAnim()
    {
        if (isGround)
        {
            anim.SetBool("Idle", true);
        }
    }

    //��ײ������
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
    //�뿪������
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
