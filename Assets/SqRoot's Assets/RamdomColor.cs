using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamdomColor : MonoBehaviour
{
    public Color color;
    public SpriteRenderer spriteRenderer;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        spriteRenderer.color = color;
    }
}
