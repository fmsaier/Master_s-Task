namespace SqR
{
    using UnityEngine;

    public class LongPress : MonoBehaviour
    {
        public static float SqrValue;
        public static bool IsJump = true;

        public float minTime;  //��ʼ����
        public float maxTime;  //�������� 
        public bool buttonPressed = false;  //��ť�Ƿ񱻰���
        public bool longPressed = false;  //�㲻�㳤��
        public float pressTime = 0f;  //���µ�ʱ��

        public void Update()
        {
            if (buttonPressed)
            {
                pressTime += Time.deltaTime;
                if (pressTime >= minTime)
                {
                    longPressed = true;
                }
            }
        }

        public void ClickDown()
        {
            if (!IsJump)
            {
                buttonPressed = true;
                IsJump = true;
            }
        } 

        public void ClickUp()
        {
            if (buttonPressed)
            {
                buttonPressed = false;
                if (!longPressed)
                {
                    SqrValue = minTime;
                }
                else if (pressTime >= maxTime)
                {
                    SqrValue = maxTime;
                }
                else
                {
                    SqrValue = pressTime;
                }
                pressTime = 0f;
                longPressed = false;
            }
        }
    }
}
