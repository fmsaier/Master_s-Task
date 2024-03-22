using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using zaaPRo;

namespace zaaPro
{
    public class Arrow : MonoBehaviour
    {
        float timer;
     


    
        private void Update()
        {
            timer += Time.deltaTime;
            if(timer>=3)
            {
                Destroy(gameObject);
                timer = 0;
            }
            if(VirusControl.instance.isTime)
            {
                transform.gameObject.SetActive(false);
              
            }
            if (Man.instance.isDie)
            {
                transform.gameObject.SetActive(false);
             

            }
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("citywall"))
            {
                Destroy(gameObject);
            }
            if (other.CompareTag("virus"))
            {
                EnenmyVirus enenmyVirus = other.GetComponent<EnenmyVirus>();
                if(enenmyVirus.attack==2&&Buttonvoid.instance.isKnow1)
                {
                    CanvasVoid2.instance.transform.GetChild(3).gameObject.SetActive(true);
                    Time.timeScale = 0;
                    Buttonvoid.instance.isKnow1 = false;
                }
                if(enenmyVirus.hp==2&& Buttonvoid.instance.isKnow2)
                {
                    CanvasVoid2.instance.transform.GetChild(4).gameObject.SetActive(true);
                    Time.timeScale = 0;
                    Buttonvoid.instance.isKnow2 = false;
                }
                if (enenmyVirus.defense==1 && Buttonvoid.instance.isKnow3)
                {
                    CanvasVoid2.instance.transform.GetChild(5).gameObject.SetActive(true);
                    Time.timeScale = 0;
                    Buttonvoid.instance.isKnow3 = false;
                }

                enenmyVirus.hp -= 1;
                Destroy(gameObject);
            }
        }
    }
}

