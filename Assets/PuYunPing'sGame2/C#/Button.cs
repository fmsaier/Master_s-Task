using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToPYP : MonoBehaviour
{
    public string StringScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToGame2()
    {
        SceneManager.LoadScene("Game2PYP");
    }

    public void Next()
    {
        if (WholePYP.PYPElement<=8)
        {
            WholePYP.PYPElement += 1;
        }
        else
        {
            SceneManager.LoadScene(StringScene);
        }
    }

    public void BackAgain()
    {
        SceneManager.LoadScene("Game2BeginPOYP");
    }
}
