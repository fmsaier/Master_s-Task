using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//创建人： Trigger 
//功能说明：
//***************************************** 
public class Song : MonoBehaviour
{
    private float rotateSpeed;
    private bool isSinging;
    private float scaleSpeed;
    private Transform outsideCircle;
    private AudioSource audioSource;
    private CircleCollider2D collider2D;
    private bool stopSinging;

    public bool StopSinging { get => stopSinging; set => stopSinging = value; }

    void Start()
    {
        outsideCircle = transform.GetChild(0);
        scaleSpeed = 5;
        rotateSpeed = 120;
        audioSource = GetComponent<AudioSource>();
        collider2D = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        transform.Rotate(rotateSpeed*Time.deltaTime*Vector3.forward);
        if (isSinging)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.volume = 1;
                audioSource.Play();
                collider2D.enabled = true;
            }
            if (transform.localScale.x<=5)
            {
                transform.localScale += scaleSpeed * Time.deltaTime * Vector3.one;
            }
            else
            {
                outsideCircle.gameObject.SetActive(true);
                if (outsideCircle.localScale.x<1)
                {
                    outsideCircle.localScale += scaleSpeed*0.8f * Time.deltaTime * Vector3.one;
                }
            }
        }
        else
        {
            if (collider2D.enabled)
            {
                collider2D.enabled = false;
            }         
            if (outsideCircle.localScale.x>=0.8)
            {
                outsideCircle.localScale -= scaleSpeed * 5 * Time.deltaTime * Vector3.one;
            }
            else
            {
                outsideCircle.gameObject.SetActive(false);
                if (transform.localScale.x>0)
                {                   
                    transform.localScale -= scaleSpeed * 3 * Time.deltaTime * Vector3.one;
                    if (transform.localScale.x<=0)
                    {
                        transform.localScale = Vector3.zero;
                    }
                }
                if (audioSource.volume>0)
                {
                    audioSource.volume -=  Time.deltaTime;
                    if (audioSource.volume<=0)
                    {
                        audioSource.Stop();
                        StopSinging = true;
                    }
                }
            }
        }
    }

    public void SetSingingState(bool state)
    {
        isSinging = state;
    }
}
