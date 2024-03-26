using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace YingMo
{
    public class BossFightManager : MonoBehaviour
    {
        public GameObject MyHandle;
        public GameObject Boss;
        public GameObject Cam;

        public void BossFight()
        {
            MyHandle?.SetActive(true);
            Boss?.SetActive(true);
            CameraFollow cameraFollow = Cam.GetComponent<CameraFollow>();
            cameraFollow.enabled = false;
        }
    }
}
