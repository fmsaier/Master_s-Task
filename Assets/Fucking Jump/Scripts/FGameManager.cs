using System.Collections;
using System.Collections.Generic;
using TMPro;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FGameManager : MonoBehaviour
{
    public static FGameManager Instance;
    public bool gameStart = false;
    public bool isPausing = false;
    float blockTimer = 0;
    float helpTimer = 0;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(Init());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

        if (gameStart)
        {
            blockTimer += Time.deltaTime;
            helpTimer += Time.deltaTime;
            if (blockTimer > 0.4f)
            {
                blockTimer = 0;
                GameObject first = Instantiate(FResourceManager.Instance.Block, new Vector3(9.5f, 5f + Random.Range(-1, 1), 0), Quaternion.identity);
                Instantiate(FResourceManager.Instance.Block, new Vector3(9.5f, first.transform.position.y - 10 + Random.Range(-0.3f, 0.3f), 0), Quaternion.identity);
            }
            if (helpTimer > 5)
            {
                helpTimer = 0;
                int number = Random.Range(0, 100);
                if (number >= 0 && number <= 20)
                {
                    GameObject vegetable;
                    if (number % 2 == 0)
                        vegetable = Instantiate(FResourceManager.Instance.Vegetable, new Vector3(9.5f, Random.Range(1.5f, 3), 0), Quaternion.identity);
                    else
                        vegetable = Instantiate(FResourceManager.Instance.Vegetable, new Vector3(9.5f, -Random.Range(1.5f, 3), 0), Quaternion.identity);
                    vegetable.GetComponent<Rigidbody2D>().velocity = new Vector3(-4, 0, 0);
                }
            }
        }
        else
        {
            if (Input.touchCount > 0)
                Pause();
        }
    }

    public void Pause()
    {
        if (!isPausing)
        {
            isPausing = true;
            FResourceManager.Instance.PauseTips.SetActive(true);
            FResourceManager.Instance.PauseButton.image.sprite = FResourceManager.Instance.ContinueIcon;
            Time.timeScale = 0;
        }
        else
        {
            isPausing = false;
            FResourceManager.Instance.PauseTips.SetActive(false);
            FResourceManager.Instance.PauseButton.image.sprite = FResourceManager.Instance.PauseIcon;
            Time.timeScale = 1;
        }
    }

    public void Shoot(GameObject gameObject)
    {
        GameObject bullet = Instantiate(gameObject, new Vector3(9.5f, Random.Range(-1.5f, 1.5f), 0), gameObject.transform.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(-5, 0, 0);
    }

    public IEnumerator Init()
    {
        yield return StartCoroutine(ChangeInfo(FResourceManager.Instance.Info
            , "欢迎来到酒城泸州，让我们和元元一起来学习预防癌症的知识吧！", 2));

        yield return StartCoroutine(ChangeInfo(FResourceManager.Instance.Info
            , "你将依次击败肝癌、乳房癌、肛门癌、肺癌，接下来我将为你介绍如何预防他们", 2));

        yield return StartCoroutine(ChangeInfo(FResourceManager.Instance.InfoPlus
            , "生活中做好饮食方面的护理、改善生活的习惯、积极治疗原发病情等，对于预防肝癌有一定的作用。肝癌的病因一般和饮食不当、不良生活习惯、肝脏疾病没有得到有效治疗等原因有关。在出现病情以后建议配合医生检查和治疗。\r\n\r\n1、做好饮食方面护理：饮食上尽量保持清淡健康、饮食规律等。可以适当的吃一些新鲜的水果和蔬菜，有利于肝脏功能的运行。对于饮食不当导致的病情有预防的作用。\r\n\r\n2、改善生活习惯：可以通过改善生活习惯来保持身体健康，比如避免熬夜、早睡早起、适当做运动、适当的饮水等。对于经常熬夜、作息不规律、过度劳累等不良习惯引起的肝癌病情有预防作用。\r\n\r\n3、积极治疗原发病情：如果本身就有肝脏疾病的存在，比如乙肝、肝硬化、酒精肝等高危人群，可以通过积极治疗原发病情来预防肝癌出现，对于肝脏疾病没有得到有效治疗引起的病情有预防作用。"
            , 3));

        yield return StartCoroutine(ChangeInfo(FResourceManager.Instance.InfoPlus
            , "乳腺癌的预防方法主要包括保持良好的饮食习惯、保持良好的生活习惯、适当运动、定期体检、保持良好的心态等。\r\n\r\n1、保持良好的饮食习惯\r\n在日常生活中，建议患者保持清淡饮食，避免食用辛辣、油腻等刺激性食物，如辣椒、炸鸡等，以免对身体造成刺激，导致内分泌失调，从而增加患乳腺癌的风险。\r\n\r\n2、保持良好的生活习惯\r\n患者平时需要保持良好的生活习惯，避免熬夜，保持充足的睡眠时间，以免导致机体免疫力下降，增加患病风险。\r\n\r\n3、适当运动\r\n适当运动不仅可以促进机体新陈代谢，还可以提高机体免疫力，有助于预防疾病。建议患者可以适当进行慢跑、游泳等体育锻炼。\r\n\r\n4、定期体检\r\n乳腺癌是一种常见的恶性肿瘤，其发生与肥胖、高脂饮食等因素有关。建议患者可以定期到医院进行体检，有助于明确是否存在乳腺癌。"
             , 3));

        yield return StartCoroutine(ChangeInfo(FResourceManager.Instance.InfoPlus
             , "1、预防肛门癌要积极的治疗肛周疾病\r\n　　肛周疾病会给肛门部位带来局部不良刺激、反复刺激，从而容易引发肛门癌的发生。比如反复肛瘘发作，局部溃疡的反复发作，恶性刺激、反复刺激，可以导致基因突变，导致肿瘤细胞产生。因此想要预防肛门癌，一定要积极的治疗肛周部位的疾病。有病得早治，尤其肛瘘，不可能通过自行痊愈，那么这种情况下可能就要做手术。还有就是如果发现局部早期病变，肛门溃疡，发现肛门长小肿物，早期把它切掉，在没有癌变或者在癌前病变的时候把它切掉，就不会变成癌，可以很好的预防癌症的发生。\r\n　　2、预防肛门癌还要注意局部的清洁卫生\r\n　　个人卫生上的预防是必须注意肛管周围清洁，因为肛门地方很脏，里面有很多的细菌，很多毒素，反复不卫生的刺激就会增加癌症的发生几率。所以必须要注意一下肛门局部卫生，每天解完大便以后用清水清洗肛门，可以达到比较好的预防肛肠疾病的目的。\r\n　　3、养成良好的排便习惯\r\n　　养成良好的排便习惯，不要留宿便，宿便之后肠腔里面大量的粪便堆积，粪便里面有毒素，被人体吸收以后，也会造成肛门周围的肿瘤。所以最好养成每天一次大便的习惯，最好是早起的时候排宿便。注意排便的时间也不要太长，排便的时候不要看手机。平时还要培养健康的生活饮食习惯，多摄取纤维，少油炸或太辣的食物。这样可以减少不良的饮食对肛门部位的刺激。"
             , 3));

        yield return StartCoroutine(ChangeInfo(FResourceManager.Instance.InfoPlus
            , "预防肺癌的方式一般有戒烟、远离致病因素、养成良好的生活习惯等方式，当出现肺癌疾病时，可在医生建议下通过放疗、化疗、手术等方式治疗。\r\n\r\n1、戒烟：由于烟中含有亚硝胺类的致癌物质，并且烟雾中也含有多种致癌物质，会刺激到体内的致癌因子发生改变，会使患者的基因发生突变的现象，诱发肺癌的发生。\r\n\r\n2、远离致病因素：对于预防肺癌的发生时，应远离恶劣的环境和一些物理化学致癌物，避免吸入有害物质到体内诱发癌症疾病出现，降低肺癌的发生率。\r\n\r\n3、养成良好的生活习惯：对于预防肺癌的患者在平时应避免经常吸烟喝酒，清淡饮食，多吃一些易消化的食物，避免长时间禁食辛辣刺激性的食物，多吃一些润肺的食物，比如柚子，木耳，雪梨等。"
            , 3));

        yield return StartCoroutine(ChangeInfo(FResourceManager.Instance.Info
            , "现在来击败肺癌吧，它是泸州市发病率第四高的癌症哦！", 2));

        FResourceManager.Instance.Title.text = "肝癌";
        gameStart = true;
        FResourceManager.Instance.Character.SetActive(true);
        FResourceManager.Instance.GanAiGe.SetActive(true);
        FResourceManager.Instance.HeartsParent.SetActive(true);
        FResourceManager.Instance.UpButton.onClick.
            AddListener(FResourceManager.Instance.Character.GetComponent<FPlayerController>().StartJump);
        FResourceManager.Instance.DownButton.onClick.
            AddListener(FResourceManager.Instance.Character.GetComponent<FPlayerController>().StartFall);
        FResourceManager.Instance.DownButton.onClick.
           AddListener(FResourceManager.Instance.Character.GetComponent<FPlayerController>().Shoot);
        Pause();
    }
    public IEnumerator ChangeInfo(TextMeshProUGUI info, string content, float timeGap)
    {
        float timer = 0;
        info.text = content;
        while (timer < timeGap)
        {
            timer += Time.deltaTime;
            Color color = info.color;
            color.a = 0.5f * timer;
            info.color = color;
            yield return null;
        }
        timer = 0;
        while (timer < timeGap)
        {
            timer += Time.deltaTime;
            Color color = info.color;
            color.a = 1 - 0.5f * timer;
            info.color = color;
            yield return null;
        }
    }

    public void ReStart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Fucking Jump");
    }
    public void NextLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("luzhou");
    }
    public void Leave()
    {
        SceneManager.LoadScene(1);
    }

}
