using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Yuki
{
    public class Bullet : MonoBehaviour
    {
        private void Start()
        {
            StartCoroutine(RegularDestruction());
        }

        private IEnumerator RegularDestruction()
        {
            yield return new WaitForSeconds(10);

            Destroy(gameObject);
        }
    }
}

