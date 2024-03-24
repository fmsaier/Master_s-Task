using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Merryfling
{
    public class PlayerController : MonoBehaviour
    {
        [Header("ʳ����Ϣ")]
        private const string goodFood = "GoodFood";

        [Header("����")]
        public float forceFactor = 50f;
        private bool isDrag;
        private float moveInterval = 0.2f;

        [Header("ָʾ")]
        public GameObject prefabArrow;
        public GameObject curArrow;
        private Vector2 startPos;
        private Vector2 endPos;

        [Header("������Ϣ")]
        public int jumpCount = 0;
        private float getCountTimer;         // �������Ӽ�ʱ��
        public float getCountInterval;         // �������Ӽ��
        public Text countCal;           // ����ͳ��
        public GameObject jumpCountPicPrefab;           // ��Ծ����UIԤ����
        public Transform jumpCountContainer;            // ��Ծ����UI�ĸ�����

        private void Start()
        {
            isDrag = false;
            curArrow.SetActive(false);
        }

        private void Update()
        {
            Jump();
            FlashCountTimer();
            CheckJumpCountPic();
            AuthorChannel();
        }

        private void Jump()
        {
            if (Input.touchCount > 0 && jumpCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

                if (touch.phase == TouchPhase.Began)
                {
                    isDrag = true;
                    startPos = touchPosition;
                    curArrow.SetActive(true);
                }

                if (isDrag && touch.phase == TouchPhase.Moved)
                {
                    endPos = touchPosition;
                    Vector2 dir = (startPos - endPos).normalized;
                    float dis = Vector2.Distance(startPos, endPos);
                    curArrow.transform.localScale = new Vector3(dis, 1f, 1f);
                    float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                    curArrow.transform.rotation = Quaternion.Euler(0, 0, angle);
                }

                if (isDrag && touch.phase == TouchPhase.Ended)
                {
                    isDrag = false;
                    endPos = touchPosition;
                    Vector2 dir = (startPos - endPos).normalized;
                    float dis = Vector2.Distance(startPos, endPos);
                    GetComponent<Rigidbody2D>().AddForce(dis * dir * forceFactor);
                    curArrow.SetActive(false);
                    jumpCount--;
                }
            }
        }

        IEnumerator MoveToCenter(Collider2D collision)
        {
            float moveTime = 0f;
            Vector3 startPos = transform.position;
            
            while (moveTime < moveInterval&& collision.gameObject)
            {
                transform.position = Vector3.Lerp(startPos, collision.transform.position, moveTime / moveInterval);
                moveTime += Time.deltaTime;
                yield return null;
            }
            transform.position = collision.transform.position;

            Destroy(collision.gameObject); // ���ٴ�������ʳ�����
        }

        private void FlashCountTimer()
        {
            if (getCountTimer <= 0)
            {
                getCountTimer = getCountInterval;
                jumpCount++;
            }
            getCountTimer -= Time.deltaTime;
            countCal.text = "��ǰ����Ϊ" + jumpCount + ",����" + getCountTimer.ToString("F1") + "s������һ������";
        }

        private void CheckJumpCountPic()
        {
            if (jumpCountContainer&&jumpCountPicPrefab)
            {
                if(jumpCountContainer.childCount<jumpCount)
                {
                    Instantiate(jumpCountPicPrefab, jumpCountContainer);
                }
                if(jumpCountContainer.childCount > jumpCount)
                {
                    Destroy(jumpCountContainer.GetChild(jumpCountContainer.childCount - 1).gameObject);
                }
            }
        }

        private void AuthorChannel()
        {
            if(Input.GetKeyDown(KeyCode.P))
            {
                Debug.Log("P");
                jumpCount++;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag(goodFood))
            {
                jumpCount++;

                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                StartCoroutine(MoveToCenter(collision));
            }
        }
    }
}
