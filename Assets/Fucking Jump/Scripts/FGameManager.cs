using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
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
            , "��ӭ�����Ƴ����ݣ������Ǻ�ԪԪһ����ѧϰԤ����֢��֪ʶ�ɣ�", 2));

        yield return StartCoroutine(ChangeInfo(FResourceManager.Instance.Info
            , "�㽫���λ��ܸΰ����鷿�������Ű����ΰ����������ҽ�Ϊ��������Ԥ������", 2));

        yield return StartCoroutine(ChangeInfo(FResourceManager.Instance.InfoPlus
            , "������������ʳ����Ļ������������ϰ�ߡ���������ԭ������ȣ�����Ԥ���ΰ���һ�������á��ΰ��Ĳ���һ�����ʳ��������������ϰ�ߡ����༲��û�еõ���Ч���Ƶ�ԭ���йء��ڳ��ֲ����Ժ������ҽ���������ơ�\r\n\r\n1��������ʳ���滤����ʳ�Ͼ��������嵭��������ʳ���ɵȡ������ʵ��ĳ�һЩ���ʵ�ˮ�����߲ˣ������ڸ��๦�ܵ����С�������ʳ�������µĲ�����Ԥ�������á�\r\n\r\n2����������ϰ�ߣ�����ͨ����������ϰ�����������彡����������ⰾҹ����˯�����ʵ����˶����ʵ�����ˮ�ȡ����ھ�����ҹ����Ϣ�����ɡ��������۵Ȳ���ϰ������ĸΰ�������Ԥ�����á�\r\n\r\n3����������ԭ�����飺���������и��༲���Ĵ��ڣ������ҸΡ���Ӳ�����ƾ��εȸ�Σ��Ⱥ������ͨ����������ԭ��������Ԥ���ΰ����֣����ڸ��༲��û�еõ���Ч��������Ĳ�����Ԥ�����á�"
            , 3));

        yield return StartCoroutine(ChangeInfo(FResourceManager.Instance.InfoPlus
            , "���ٰ���Ԥ��������Ҫ�����������õ���ʳϰ�ߡ��������õ�����ϰ�ߡ��ʵ��˶���������졢�������õ���̬�ȡ�\r\n\r\n1���������õ���ʳϰ��\r\n���ճ������У����黼�߱����嵭��ʳ������ʳ������������ȴ̼���ʳ���������ը���ȣ������������ɴ̼��������ڷ���ʧ�����Ӷ����ӻ����ٰ��ķ��ա�\r\n\r\n2���������õ�����ϰ��\r\n����ƽʱ��Ҫ�������õ�����ϰ�ߣ����ⰾҹ�����ֳ����˯��ʱ�䣬���⵼�»����������½������ӻ������ա�\r\n\r\n3���ʵ��˶�\r\n�ʵ��˶��������Դٽ������³´�л����������߻�����������������Ԥ�����������黼�߿����ʵ��������ܡ���Ӿ������������\r\n\r\n4���������\r\n���ٰ���һ�ֳ����Ķ����������䷢������֡���֬��ʳ�������йء����黼�߿��Զ��ڵ�ҽԺ������죬��������ȷ�Ƿ�������ٰ���"
             , 3));

        yield return StartCoroutine(ChangeInfo(FResourceManager.Instance.InfoPlus
             , "1��Ԥ�����Ű�Ҫ���������Ƹ��ܼ���\r\n�������ܼ���������Ų�λ�����ֲ������̼��������̼����Ӷ������������Ű��ķ��������練�������������ֲ�����ķ������������Դ̼��������̼������Ե��»���ͻ�䣬��������ϸ�������������ҪԤ�����Ű���һ��Ҫ���������Ƹ��ܲ�λ�ļ������в������Σ����������������ͨ������Ȭ������ô��������¿��ܾ�Ҫ�����������о���������־ֲ����ڲ��䣬�������񣬷��ָ��ų�С������ڰ����е�����û�а�������ڰ�ǰ�����ʱ������е����Ͳ����ɰ������Ժܺõ�Ԥ����֢�ķ�����\r\n����2��Ԥ�����Ű���Ҫע��ֲ����������\r\n�������������ϵ�Ԥ���Ǳ���ע��ع���Χ��࣬��Ϊ���ŵط����࣬�����кܶ��ϸ�����ܶ඾�أ������������Ĵ̼��ͻ����Ӱ�֢�ķ������ʡ����Ա���Ҫע��һ�¸��žֲ�������ÿ��������Ժ�����ˮ��ϴ���ţ����Դﵽ�ȽϺõ�Ԥ���س�������Ŀ�ġ�\r\n����3���������õ��ű�ϰ��\r\n�����������õ��ű�ϰ�ߣ���Ҫ���ޱ㣬�ޱ�֮��ǻ��������ķ��ѻ�����������ж��أ������������Ժ�Ҳ����ɸ�����Χ�������������������ÿ��һ�δ���ϰ�ߣ�����������ʱ�����ޱ㡣ע���ű��ʱ��Ҳ��Ҫ̫�����ű��ʱ��Ҫ���ֻ���ƽʱ��Ҫ����������������ʳϰ�ߣ�����ȡ��ά������ը��̫����ʳ��������Լ��ٲ�������ʳ�Ը��Ų�λ�Ĵ̼���"
             , 3));

        yield return StartCoroutine(ChangeInfo(FResourceManager.Instance.InfoPlus
            , "Ԥ���ΰ��ķ�ʽһ���н��̡�Զ���²����ء��������õ�����ϰ�ߵȷ�ʽ�������ַΰ�����ʱ������ҽ��������ͨ�����ơ����ơ������ȷ�ʽ���ơ�\r\n\r\n1�����̣��������к�������������°����ʣ�����������Ҳ���ж����°����ʣ���̼������ڵ��°����ӷ����ı䣬��ʹ���ߵĻ�����ͻ��������շ��ΰ��ķ�����\r\n\r\n2��Զ���²����أ�����Ԥ���ΰ��ķ���ʱ��ӦԶ����ӵĻ�����һЩ����ѧ�°�����������к����ʵ������շ���֢�������֣����ͷΰ��ķ����ʡ�\r\n\r\n3���������õ�����ϰ�ߣ�����Ԥ���ΰ��Ļ�����ƽʱӦ���⾭�����̺Ⱦƣ��嵭��ʳ�����һЩ��������ʳ����ⳤʱ���ʳ�����̼��Ե�ʳ����һЩ��ε�ʳ��������ӣ�ľ����ѩ��ȡ�"
            , 3));

        yield return StartCoroutine(ChangeInfo(FResourceManager.Instance.Info
            , "���������ܷΰ��ɣ����������з����ʵ��ĸߵİ�֢Ŷ��", 2));

        FResourceManager.Instance.Title.text = "�ΰ�";
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

    public void Leave()
    {
        SceneManager.LoadScene("Start");
    }

}
