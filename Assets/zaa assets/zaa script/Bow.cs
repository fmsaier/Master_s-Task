using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.AssemblyQualifiedNameParser;
using UnityEngine;

namespace zaaPro
{
    public class Bow : MonoBehaviour
    {
        // Start is called before the first frame update
        public float angle1;
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Vector2 mousePos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 thisPos=new Vector2(transform.position.x, transform.position.y);
            float angle = angleChange(mousePos, thisPos);
            transform.rotation = Quaternion.Euler(0, 0, angle-angle1);


        }

        private float angleChange(Vector2 a, Vector2 b)
        {
            return Mathf.Atan2(a.y-b.y,a.x-b.x)*Mathf.Rad2Deg;
        }
    }
}

