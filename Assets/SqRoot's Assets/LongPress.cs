namespace SqR
{
    using UnityEngine;

    public class LongPress : MonoBehaviour
    {
        public static float SqrValue;
        public static bool IsJump = true;

        public float minTime;  //开始底限
        public float maxTime;  //长按上限 
        public bool buttonPressed = false;  //按钮是否被按下
        public bool longPressed = false;  //算不算长按
        public float pressTime = 0f;  //按下的时间

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
