using UnityEngine;
using SqR;
using UnityEngine.UI;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing;  //ƽ������

    public Text stageNum;
    public Text meter;
    public GameObject player;
    public Transform trans;

    private void Start()
    {
        trans = player.GetComponent<Transform>();
    }
    private void Update()
    {
        stageNum.text = "����������" + SqR.LongPress.StageNum.ToString();
        meter.text = "�ж����룺" + trans.position.x.ToString("0.00");
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            if (transform.position != target.position)
            {
                Vector3 targetPos = new Vector3(target.position.x, target.position.y, -10);
                transform.position = Vector3.Lerp(transform.position, targetPos, smoothing);
            }
        }
    }
}