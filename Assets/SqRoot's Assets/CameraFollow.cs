using UnityEngine;
using SqR;
using UnityEngine.UI;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing;  //平滑因子

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
        stageNum.text = "格子数量：" + SqR.LongPress.StageNum.ToString();
        meter.text = "行动距离：" + trans.position.x.ToString("0.00");
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