using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SqR;

public class ReFresh : MonoBehaviour
{
    //���봥����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (SqR.LongPress.IsJump)
        {
            SqR.LongPress.IsJump = false;
        }
    }
}
