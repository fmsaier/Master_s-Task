using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FDiCiWangPYP : MonoBehaviour
{
    public DiCiWangPYP DiCiWang ;
    public NumberDisplayGame1PYP NumberDisplayGame1;
    // Start is called before the first frame update
    void Start()
    {
        DiCiWang = FindObjectOfType<DiCiWangPYP>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            NumberDisplayGame1.Number += 1;
            WholePYP.Game2 += 1;
            DiCiWang.SpawnPrefab();
            Destroy(gameObject);
        }
    }
}
