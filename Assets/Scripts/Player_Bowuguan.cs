using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Bowuguan : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;

    [Header("�ٶ�")]
    public float speed;

    [Header("�Ի���")]
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

    [Header("������")]
    public GameObject Handle;

    void GroundMovement()
    {
        //float horizontal_move = Input.GetAxis("Horizontal");
        //float faced_direction = Input.GetAxisRaw("Horizontal");

        /*�޶�*/
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

    //����Ч��
    void SwitchAnim()
    {
        anim.SetBool("Idle", true);
 
    }

    //��ײ������
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

    //�뿪������
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

    //������Ϸ
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
