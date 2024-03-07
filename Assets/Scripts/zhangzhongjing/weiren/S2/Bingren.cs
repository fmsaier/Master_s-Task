using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bingren : MonoBehaviour
{
    protected AudioSource deathAu;

    protected virtual void Start()
    {
        deathAu = GetComponent<AudioSource>();
    }
    public void Death()
    {
        Destroy(gameObject);
    }
    //����Ϊpublic�������������������
    public void Jump_on()
    {
        deathAu.Play();
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        Destroy(gameObject);
    }
}
