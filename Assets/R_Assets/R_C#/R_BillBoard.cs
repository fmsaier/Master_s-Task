using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class R_BillBoard : MonoBehaviour
{
    public GameObject diakongBox;
    public Text dialongText;
    public string signText;
    private bool isTouch;

    private void Start()
    {

    }
    void Update()
    {
        if (isTouch)
        {
            diakongBox.SetActive(true);
            dialongText.text = signText;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.PolygonCollider2D")
        { 
            isTouch = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.GetType().ToString() == "UnityEngine.PolygonCollider2D")
        {
            isTouch = false;
            diakongBox.SetActive(false);
        }
    }
}
