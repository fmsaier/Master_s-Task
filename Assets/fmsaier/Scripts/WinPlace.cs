using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//*****************************************
//创建人： Trigger 
//功能说明：判定玩家通关
//***************************************** 
public class WinPlace : MonoBehaviour
{
    private Transform grisTrans;
    private AudioClip audioClipToNextLevel;
    private AudioClip audioClipJudge;
    private AudioClip audioClipNormal;
    private AudioSource audioSource;
    private AsyncOperation ao;
    private CameraCtroller cc;
    private RenderColor rc;
    private Gris gris;
    private ToNextLevelScript levelScript;
    private GameObject birds;
    private CameraPosMove cpm;

    void Start()
    {
        grisTrans = GameObject.Find("Gris").transform;
        audioClipToNextLevel = Resources.Load<AudioClip>("Gris/Audioclips/BG4");
        audioClipJudge = Resources.Load<AudioClip>("Gris/Audioclips/BG3");
        audioClipNormal = Resources.Load<AudioClip>("Gris/Audioclips/BG2");
        audioSource = GameObject.Find("Evn").GetComponent<AudioSource>();
        cc = Camera.main.GetComponent<CameraCtroller>();
        rc = GameObject.Find("RenderColors").GetComponent<RenderColor>();
        gris = grisTrans.GetComponent<Gris>();
        levelScript = grisTrans.GetComponent<ToNextLevelScript>();
        ao = SceneManager.LoadSceneAsync(1);
        ao.allowSceneActivation = false;
        birds = Resources.Load<GameObject>("Prefabs/Birds");
        cpm = GameObject.Find("CameraTargetPos").GetComponent<CameraPosMove>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Gris")
        {
            if (audioSource.isPlaying)
            {             
                if (JudageTearNumEnough())
                {
                    //通关
                    if (audioSource.clip.name != audioClipToNextLevel.name)
                    {
                        StartCoroutine(ToNextLevel());
                        //Invoke("PlayNormalClip", 24);
                    }
                }
                else
                {
                    if (audioSource.clip.name != audioClipJudge.name)
                    {
                        audioSource.clip = audioClipJudge;
                        audioSource.loop = false;
                        audioSource.Play();
                        Invoke("PlayNormalClip", 30);
                    }
                }
            }
        }
    }
    /// <summary>
    /// 判断当前是否通关
    /// </summary>
    /// <returns></returns>
    private bool JudageTearNumEnough()
    {
        for (int i = 0; i < grisTrans.childCount - 1; i++)
        {
            if (grisTrans.GetChild(i).childCount <= 0)
            {
                //有空位置，代表眼泪没有收集完毕
                return false;
            }
        }
        //已经没有空位置了，通关
        return true;
    }

    private void PlayNormalClip()
    {
        audioSource.clip = audioClipNormal;
        audioSource.loop = true;
        audioSource.Play();
    }

    IEnumerator ToNextLevel()
    {
        //异步加载第二关场景
        audioSource.Stop();
        gris.cancelMove = true;
        yield return new WaitForSeconds(0.6f);
        //让玩家失去对Gris的控制权  
        gris.enabled = false;
        levelScript.enabled = true;
        levelScript.SetRigidBodyType(RigidbodyType2D.Kinematic);
        levelScript.PlayAnimation("Cry");
        //人物切换剧情动画状态1
        yield return new WaitForSeconds(1.167f);
        //人物上升空中，切换剧情动画状态2        
        levelScript.StartMove(new Vector3(328,3,0));
        yield return new WaitForSeconds(0.3f);//等待人物升空       
        //播放音乐
        audioSource.clip = audioClipToNextLevel;
        audioSource.loop = false;
        audioSource.Play();      
        yield return new WaitForSeconds(2.7f);
        //生成小花
        levelScript.PlayAnimation("Fly");
        Instantiate(birds,transform.position+new Vector3(25,8,0),Quaternion.identity);
        Instantiate(Resources.Load<GameObject>(@"Prefabs/Red"));
        cc.SetColor(new Color((float)252/255, (float)236 /255, (float)228 /255));
        //播放切换场景前的特效，并拉远摄像机视角
        cpm.SetPos(new Vector3(-8.8f, 4.4f, 10));
        cc.SetSize(10);

        yield return new WaitForSeconds(1);
        rc.StartChangeBGAlphaCutoff();
        yield return new WaitForSeconds(3);
        rc.StartChangeColorAlpha();
        yield return new WaitForSeconds(4);
        rc.StartChangeAlphaAndScaleValues();
        yield return new WaitForSeconds(5);
        cpm.SetPos(new Vector3(-13.4f, 6.6f, 10));
        cc.SetSize(5);      
        yield return new WaitForSeconds(2);
        //人物下落 328 -3        
        levelScript.StartMove(new Vector3(327.8f, -3, 0));
        yield return new WaitForSeconds(3);
        levelScript.PlayAnimation("ToIdle");
        yield return new WaitForSeconds(2);
        cpm.SetPos(new Vector3(14.6f, 6.49f, 10));
        yield return new WaitForSeconds(4);
        //切换到场景2（关卡2）
        ao.allowSceneActivation = true;
    }
}
