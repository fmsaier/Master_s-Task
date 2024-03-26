using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lio;
using UnityEngine.SceneManagement;

namespace Lio
{
    public class Dialog : MonoBehaviour
    {
        public GameObject next;
        public string nextScene;

        // Start is called before the first frame update
        void Start()
        {
            return;
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                if (next != null)
                {
                    next.SetActive(true);
                }
                else if(nextScene!="")
                {
                    SceneManager.LoadScene(nextScene);
                }
                gameObject.SetActive(false);
            }
            return;
        }
    }
}
