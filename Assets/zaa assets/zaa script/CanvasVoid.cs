using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasVoid : MonoBehaviour
{
    // Start is called before the first frame update
    public static CanvasVoid instance;
   
    void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
