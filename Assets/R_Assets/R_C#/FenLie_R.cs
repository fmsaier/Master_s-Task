using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenLie_R : MonoBehaviour
{
    [SerializeField] private Transform[] Pos;
    [SerializeField] private GameObject cell;
    Enemy_R e;

    private void Start()
    {
        e = GetComponent<Enemy_R>();
    }

   public void Fenlie()
    {
        for (int i = 0; i < Pos.Length; i++)
        {
            Instantiate(cell, Pos[i]);
        }
    }
}
