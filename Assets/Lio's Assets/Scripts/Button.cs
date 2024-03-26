using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lio;
using UnityEngine.SceneManagement;

namespace Lio
{
    public class Button : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            return;
        }

        // Update is called once per frame
        void Update()
        {
            return;
        }

        public void OnClick()
        {
            SceneManager.LoadScene(1);
        }
    }
}
