using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//创建人： Trigger 
//功能说明：石像，生成眼泪并存贮相关数据
//***************************************** 
public class Stone : MonoBehaviour
{
    [HideInInspector]
    public GameObject tearsGo;
    private Transform[] roadsTrans;
    private int tearNum;
    [HideInInspector]
    public int stopTearNum;
    private GameObject grisGo;//-13.4 6.6
    private bool startEndScript;
    private AudioSource audioSource;
    private AudioClip audioClip;
    private Gris gris;
    private Rigidbody2D rigid;
    private CameraCtroller cc;
    private CameraPosMove cpm;
    void Start()
    {
        tearsGo = Resources.Load<GameObject>("Prefabs/Tear");
        Transform pointsTrans= transform.Find("Points");
        roadsTrans = new Transform[pointsTrans.childCount];
        for (int i = 0; i < roadsTrans.Length; i++)
        {
            roadsTrans[i] = pointsTrans.GetChild(i);
        }
        //foreach (var item in roadsTrans)
        //{
        //    Debug.Log(item);
        //}
        grisGo = GameObject.Find("Gris");
        Invoke("StartcreatingTears",4);
        audioClip= Resources.Load<AudioClip>(@"Gris/Audioclips/BG2");
        audioSource = GameObject.Find("Evn").GetComponent<AudioSource>();
        gris = grisGo.GetComponent<Gris>();
        rigid = gris.GetComponent<Rigidbody2D>();
        cc = Camera.main.GetComponent<CameraCtroller>();
        cpm = GameObject.Find("CameraTargetPos").GetComponent<CameraPosMove>();
    }

    void Update()
    {
        if (tearNum>=5)
        {
            CancelInvoke();
            tearNum = 0;
        }
        if (stopTearNum>=5&&!startEndScript)
        {
            EndScriptOneSet();
            startEndScript = true;
        }
        if (startEndScript)
        {
            //需要渐变处理的一些内容
            //Camera.main.transform.localPosition= Vector3.Lerp(Camera.main.transform.localPosition, new Vector3(-13.4f, 6.6f, 10),1*Time.deltaTime);
            audioSource.volume -= Time.deltaTime*0.1f;
            if (audioSource.volume<=0)
            {
                //移动结束
                audioSource.clip = audioClip;
                audioSource.volume = 1;
                audioSource.Play();
                Destroy(this);
            }
        }
    }

    private void StartcreatingTears()
    {
        InvokeRepeating("CreateTear",0,2);
    }

    private void CreateTear()
    {        
        GameObject go= Instantiate(tearsGo, roadsTrans[0].position, Quaternion.identity);
        Tear tear = go.GetComponent<Tear>();
        tear.roadsTrans= roadsTrans;
        tear.finalIndex = roadsTrans.Length - 1-tearNum;
        tearNum++;
        tear.stone = this;
    }

    private void EndScriptOneSet()
    {
        gris.enabled = true;
        rigid.bodyType = RigidbodyType2D.Dynamic;
        //Camera.main.transform.SetParent(grisGo.transform);
        //Camera.main.GetComponent<CameraCtroller>().SetPos(new Vector3(-13.4f, 6.6f, 10));
        //Camera.main.transform.localPosition = new Vector3(-13.4f, 6.6f, 10);
        cpm.SetPos(new Vector3(-13.4f, 6.6f, 10));
        cc.startPosLerp = true;
    }
}
