using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//*****************************************
//创建人： Trigger 
//功能说明：触发BOSS战
//***************************************** 
public class LastScript : MonoBehaviour
{
    private SpriteRenderer sr;
    public bool startLerp;
    public float targetValue;
    private GameObject grisGo;
    private AudioSource audioSource;
    private AudioClip bossAudioClip;
    private AudioClip lastAudioClip;
    private GameObject changeCameraArea;
    private Gris gris;
    private AsyncOperation ao;
    private GameObject birds;

    void Start()
    {
        sr = GameObject.Find("BlackSky").GetComponent<SpriteRenderer>();
        grisGo = GameObject.Find("BOSS");
        grisGo.SetActive(false);
        audioSource= GameObject.Find("Evn").GetComponent<AudioSource>();
        bossAudioClip = Resources.Load<AudioClip>("Gris/Audioclips/Boss");
        lastAudioClip= Resources.Load<AudioClip>("Gris/Audioclips/Sing");
        changeCameraArea = GameObject.Find("ChangeCameraArea");
        gris = GameObject.Find("Gris").GetComponent<Gris>();
        ao= SceneManager.LoadSceneAsync(0);
        ao.allowSceneActivation = false;
        birds = Resources.Load<GameObject>("Prefabs/Birds");
    }

    void Update()
    {
        if (startLerp)
        {
            if (targetValue>0)
            {    
                sr.color += new Color(0, 0, 0, 0.2f) * Time.deltaTime;
            }
            else
            {
                sr.color -= new Color(0, 0, 0, 0.2f) * Time.deltaTime;
            }

            if (Mathf.Abs(sr.color.a - targetValue)<=0.05f)
            {
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b,targetValue);
                if (targetValue>=1)//生成BOSS，开始战斗
                {
                    if (!grisGo.activeInHierarchy)
                    {
                        grisGo.SetActive(true);
                        startLerp = false;
                    }
                   
                }
            }
        }
    } 
    /// <summary>
    /// 开启或关闭Boss战
    /// </summary>
    /// <param name="targetVal"></param>
    public void StartLerp(float targetVal)
    {
        if (targetVal>=1)
        {
            //开始BOSS战
            audioSource.clip = bossAudioClip;
            audioSource.volume = 0.2f;
            audioSource.Play();
            changeCameraArea.SetActive(false);
        }
        else
        {
            //通关
            audioSource.clip = lastAudioClip;
            audioSource.volume = 1;
            audioSource.Play();
            gris.PlaySingAnimation();
            Invoke("LoadScene",80);
            Invoke("CreateBirds", 5);
        }
        targetValue = targetVal;
        startLerp = true;

    }

    private void LoadScene()
    {
        ao.allowSceneActivation = true;
    }

    private void CreateBirds()
    {        
        Instantiate(birds,gris.transform.position-new Vector3(-20,-7,0),Quaternion.identity);
    }
}
