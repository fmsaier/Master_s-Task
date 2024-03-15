using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_huatuo_wuqinxi : MonoBehaviour
{
    public AudioSource collectionAu;
    private Animator anim;


    private int collection;
    public Text collectionText;

    public GameObject Chengjiu;
    public GameObject Timeline;
    public GameObject dialogAgain;

    [Header("ͼ��")]
    public GameObject Hu_1;
    public GameObject Lu_1;
    public GameObject Xiong_1;
    public GameObject Yuan_1;
    public GameObject Niao_1;
    public GameObject Hu_2;
    public GameObject Lu_2;
    public GameObject Xiong_2;
    public GameObject Yuan_2;
    public GameObject Niao_2;
    public GameObject Hu_3;
    public GameObject Lu_3;
    public GameObject Xiong_3;
    public GameObject Yuan_3;
    public GameObject Niao_3;

    [Header("��Ч")]
    public GameObject tiger;
    public GameObject deer;
    public GameObject bear;
    public GameObject ape;
    public GameObject bird;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        collection = 0;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    Action();
    //}

    public void Tiger()
    {
        Vector3 prefabPosition = tiger.transform.position;
        Quaternion prefabRotation = tiger.transform.rotation;
        Instantiate(tiger, prefabPosition, prefabRotation);
        anim.SetTrigger("Hu");
        if (Hu_1 && Hu_1.active)
        {
            collectionAu.Play();
            Destroy(Hu_1);
            collection += 20;
            collectionText.text = "�÷֣�" + collection;
        }
        else if (Hu_2 && Hu_2.active)
        {
            collectionAu.Play();
            Destroy(Hu_2);
            collection += 20;
            collectionText.text = "�÷֣�" + collection;
        }
        else if (Hu_3 && Hu_3.active)
        {
            collectionAu.Play();
            Destroy(Hu_3);
            collection += 20;
            collectionText.text = "�÷֣�" + collection;
        }
    }
    public void Deer()
    {
        Vector3 prefabPosition = deer.transform.position;
        Quaternion prefabRotation = deer.transform.rotation;
        Instantiate(deer, prefabPosition, prefabRotation);
        anim.SetTrigger("Lu");
        if (Lu_1 && Lu_1.active)
        {
            collectionAu.Play();
            Destroy(Lu_1);
            collection += 20;
            collectionText.text = "�÷֣�" + collection;
        }
        else if (Lu_2 && Lu_2.active)
        {
            collectionAu.Play();
            Destroy(Lu_2);
            collection += 20;
            collectionText.text = "�÷֣�" + collection;
        }
        else if (Lu_3 && Lu_3.active)
        {
            collectionAu.Play();
            Destroy(Lu_3);
            collection += 20;
            collectionText.text = "�÷֣�" + collection;
        }
    }
    public void Bear()
    {
        Vector3 prefabPosition = bear.transform.position;
        Quaternion prefabRotation = bear.transform.rotation;
        Instantiate(bear, prefabPosition, prefabRotation);
        anim.SetTrigger("Xiong");
        if (Xiong_1 && Xiong_1.active)
        {
            collectionAu.Play();
            Destroy(Xiong_1);
            collection += 20;
            collectionText.text = "�÷֣�" + collection;
        }
        else if (Xiong_2 && Xiong_2.active)
        {
            collectionAu.Play();
            Destroy(Xiong_2);
            collection += 20;
            collectionText.text = "�÷֣�" + collection;
        }
        else if (Xiong_3 && Xiong_3.active)
        {
            collectionAu.Play();
            Destroy(Xiong_3);
            collection += 20;
            collectionText.text = "�÷֣�" + collection;
        }
    }
    public void Ape()
    {
        Vector3 prefabPosition = ape.transform.position;
        Quaternion prefabRotation = ape.transform.rotation;
        Instantiate(ape, prefabPosition, prefabRotation);
        anim.SetTrigger("Yuan");
        if (Yuan_1 && Yuan_1.active)
        {
            collectionAu.Play();
            Destroy(Yuan_1);
            collection += 20;
            collectionText.text = "�÷֣�" + collection;
        }
        else if (Yuan_2 && Yuan_2.active)
        {
            collectionAu.Play();
            Destroy(Yuan_2);
            collection += 20;
            collectionText.text = "�÷֣�" + collection;
        }
        else if (Yuan_3 && Yuan_3.active)
        {
            collectionAu.Play();
            Destroy(Yuan_3);
            collection += 20;
            collectionText.text = "�÷֣�" + collection;
        }
    }
    public void Bird()
    {
        Vector3 prefabPosition = bird.transform.position;
        Quaternion prefabRotation = bird.transform.rotation;
        Instantiate(bird, prefabPosition, prefabRotation);
        anim.SetTrigger("Niao");
        if (Niao_1 && Niao_1.active)
        {
            collectionAu.Play();
            Destroy(Niao_1);
            collection += 20;
            collectionText.text = "�÷֣�" + collection;
        }
        else if (Niao_2 && Niao_2.active)
        {
            collectionAu.Play();
            Destroy(Niao_2);
            collection += 20;
            collectionText.text = "�÷֣�" + collection;
        }
        else if (Niao_3 && Niao_3.active)
        {
            collectionAu.Play();
            Destroy(Niao_3);
            collection += 20;
            collectionText.text = "�÷֣�" + collection;
        }
    }
    //void Action()
    //{
    //    if (Input.GetKeyDown(KeyCode.W))
    //    {
    //        anim.SetTrigger("Hu");
    //        if(Hu_1 && Hu_1.active)
    //        {
    //            collectionAu.Play();
    //            Destroy(Hu_1);
    //            collection += 20;
    //            collectionText.text = "�÷֣�" + collection;
    //        }
    //        else if (Hu_2 && Hu_2.active)
    //        {
    //            collectionAu.Play();
    //            Destroy(Hu_2);
    //            collection += 20;
    //            collectionText.text = "�÷֣�" + collection;
    //        }
    //        else if (Hu_3 && Hu_3.active)
    //        {
    //            collectionAu.Play();
    //            Destroy(Hu_3);
    //            collection += 20;
    //            collectionText.text = "�÷֣�" + collection;
    //        }
    //    }
    //    if (Input.GetKeyDown(KeyCode.A))
    //    {
    //        anim.SetTrigger("Lu");
    //        if (Lu_1 && Lu_1.active)
    //        {
    //            collectionAu.Play();
    //            Destroy(Lu_1);
    //            collection += 20;
    //            collectionText.text = "�÷֣�" + collection;
    //        }
    //        else if(Lu_2 && Lu_2.active)
    //        {
    //            collectionAu.Play();
    //            Destroy(Lu_2);
    //            collection += 20;
    //            collectionText.text = "�÷֣�" + collection;
    //        }
    //        else if(Lu_3 && Lu_3.active)
    //        {
    //            collectionAu.Play();
    //            Destroy(Lu_3);
    //            collection += 20;
    //            collectionText.text = "�÷֣�" + collection;
    //        }
    //    }
    //    if (Input.GetKeyDown(KeyCode.S))
    //    {
    //        anim.SetTrigger("Xiong");
    //        if (Xiong_1 && Xiong_1.active)
    //        {
    //            collectionAu.Play();
    //            Destroy(Xiong_1);
    //            collection += 20;
    //            collectionText.text = "�÷֣�" + collection;
    //        }
    //        else if(Xiong_2 && Xiong_2.active)
    //        {
    //            collectionAu.Play();
    //            Destroy(Xiong_2);
    //            collection += 20;
    //            collectionText.text = "�÷֣�" + collection;
    //        }
    //        else if(Xiong_3 && Xiong_3.active)
    //        {
    //            collectionAu.Play();
    //            Destroy(Xiong_3);
    //            collection += 20;
    //            collectionText.text = "�÷֣�" + collection;
    //        }
    //    }
    //    if (Input.GetKeyDown(KeyCode.D))
    //    {
    //        anim.SetTrigger("Yuan");
    //        if (Yuan_1 && Yuan_1.active)
    //        {
    //            collectionAu.Play();
    //            Destroy(Yuan_1);
    //            collection += 20;
    //            collectionText.text = "�÷֣�" + collection;
    //        }
    //        else if(Yuan_2 && Yuan_2.active)
    //        {
    //            collectionAu.Play();
    //            Destroy(Yuan_2);
    //            collection += 20;
    //            collectionText.text = "�÷֣�" + collection;
    //        }
    //        else if(Yuan_3 && Yuan_3.active)
    //        {
    //            collectionAu.Play();
    //            Destroy(Yuan_3);
    //            collection += 20;
    //            collectionText.text = "�÷֣�" + collection;
    //        }
    //    }
    //    if (Input.GetKeyDown(KeyCode.X))
    //    {
    //        anim.SetTrigger("Niao");
    //        if (Niao_1 && Niao_1.active)
    //        {
    //            collectionAu.Play();
    //            Destroy(Niao_1);
    //            collection += 20;
    //            collectionText.text = "�÷֣�" + collection;
    //        }
    //        else if(Niao_2 && Niao_2.active)
    //        {
    //            collectionAu.Play();
    //            Destroy(Niao_2);
    //            collection += 20;
    //            collectionText.text = "�÷֣�" + collection;
    //        }
    //        else if(Niao_3 && Niao_3.active)
    //        {
    //            collectionAu.Play();
    //            Destroy(Niao_3);
    //            collection += 20;
    //            collectionText.text = "�÷֣�" + collection;
    //        }
    //    }
    //}
}
