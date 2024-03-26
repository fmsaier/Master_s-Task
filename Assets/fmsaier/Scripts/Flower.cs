using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//*****************************************
//创建人： Trigger 
//功能说明：开花
//***************************************** 
public class Flower : MonoBehaviour
{
    public bool bloom;
    private Animator animator;
    private GameObject tearItemGo;
    private AudioClip audioClip;

    void Start()
    {
        tearItemGo = Resources.Load<GameObject>("Prefabs/TearItemPink");
        animator = GetComponent<Animator>();
        audioClip = Resources.Load<AudioClip>("Gris/Audioclips/Bloom");
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name=="Song")
        {
            if (!bloom)
            {
                animator.Play("Bloom");
                bloom = true;
                AudioSource.PlayClipAtPoint(audioClip, transform.position);
                Invoke("CreateTearItem",1.5f);
            }
        }
    }

    private void CreateTearItem()
    {      
        GameObject itemGo= Instantiate(tearItemGo,transform.position+transform.up,Quaternion.identity);
        itemGo.name = gameObject.name;
        this.enabled = false;
    }
}
