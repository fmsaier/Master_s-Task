using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FAudioManager : MonoBehaviour
{
    public static FAudioManager Instance;
    public AudioSource audioSource;
    public AudioClip jump;
    public AudioClip fall;
    public AudioClip takeDamage;
    public AudioClip enemyTakeDamage;
    public AudioClip shoot;
    public AudioClip heal;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayEffect(AudioClip targetEffect)
    {
        audioSource.PlayOneShot(targetEffect);
    }
}
