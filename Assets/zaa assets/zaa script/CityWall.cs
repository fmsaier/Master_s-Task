using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace zaaPro
{
    public class CityWall : MonoBehaviour
    {
    
        // Update is called once per frame
        void Update()
        {
            if(CWall.instance.health<=0)
            {
                Destroy(gameObject);
            }
           
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("virus"))
            {
                EnenmyVirus enenmyVirus = other.GetComponent<EnenmyVirus>();
                CWall.instance.health -= enenmyVirus.attack;


            }
        }
    }
}

