using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class videoCtrl : MonoBehaviour
{
private VideoPlayer videoPlayer;
public GameObject aa;
public GameObject a;
private void Start() {
    videoPlayer=gameObject.GetComponent<VideoPlayer>();
}
    void Update()
    {
        if(videoPlayer.frame==(long)(videoPlayer.frameCount-1)){
afterVideo();
        }
    }
    public void afterVideo(){
            a.SetActive(true);
            aa.SetActive(true);
            gameObject.SetActive(false);
    }
}
