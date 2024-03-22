using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace zaaPro
{
    public class EnenmyVirus : MonoBehaviour
    {
        // Start is called before the first frame update
        public int hp;
        public int attack;
        public int defense;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.CompareTag("cw"))
            {
                Destroy(gameObject);
            
            }
        }

        private void Update()
        {
            if(hp<=0)
            {
                Destroy(gameObject);
            }

            if(VirusControl.instance.isDestroy)
            {
                Destroy(gameObject);
               
            }
            if (Man.instance.isDie)
            {
                Destroy(gameObject);

            }
        }
    }
}

