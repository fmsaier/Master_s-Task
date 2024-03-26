using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class FAi : MonoBehaviour
{
    public float hp = 0;
    public float attackTimer = 0;
    public float attackGap = 0;
    public float helpTimer = 0;
    public float helpGap = 0;
    public float medicineTimer = 0;
    public float medicineGap = 0;
    void Start()
    {
        StartCoroutine(MoveUp());
    }

    void Update()
    {
        attackTimer += Time.deltaTime;
        helpTimer += Time.deltaTime;
        medicineTimer += Time.deltaTime;
        if (attackTimer > attackGap)
        {
            attackTimer = 0;
            Attack();
        }
        if (helpTimer > helpGap)
        {
            helpTimer = 0;
            Help();
        }
        if (medicineTimer > medicineGap)
        {
            medicineTimer = 0;
            Medicine();
        }
    }

    public void TakeDamage(float number)
    {
        hp -= number;
        FAudioManager.Instance.PlayEffect(FAudioManager.Instance.enemyTakeDamage);
        StartCoroutine(ChangeColor());
        if (hp < 0)
            Die();
    }

    public IEnumerator ChangeColor()
    {
        float timer = 0;
        while (timer < 0.2f)
        {
            timer += Time.deltaTime;
            Color color = GetComponent<Image>().color;
            color.g = 1 - 5 * timer;
            color.b = 1 - 5 * timer;
            GetComponent<Image>().color = color;
            yield return null;
        }
        timer = 0;
        while (timer < 0.2f)
        {
            timer += Time.deltaTime;
            Color color = GetComponent<Image>().color;
            color.g = 5 * timer;
            color.b = 5 * timer;
            GetComponent<Image>().color = color;
            yield return null;
        }
    }

    public void Attack()
    {
        int random = Random.Range(0, 2);
        if (random == 0)
            FGameManager.Instance.Shoot(FResourceManager.Instance.Wine);
        else
            FGameManager.Instance.Shoot(FResourceManager.Instance.Cigarette);
    }

    public void Help()
    {
        FGameManager.Instance.Shoot(FResourceManager.Instance.Apple);
    }

    public void Medicine()
    {
        FGameManager.Instance.Shoot(FResourceManager.Instance.Medicine);
    }

    virtual public void Die()
    {

    }

    public IEnumerator MoveUp()
    {
        float timer = 0;
        while (timer < 5)
        {
            timer += Time.deltaTime;
            transform.Translate(new Vector3(0, Time.deltaTime, 0));
            yield return null;
        }
        StartCoroutine(MoveDown());
    }

    public IEnumerator MoveDown()
    {
        float timer = 0;
        while (timer < 5)
        {
            timer += Time.deltaTime;
            transform.Translate(new Vector3(0, -Time.deltaTime, 0));
            yield return null;
        }
        StartCoroutine(MoveUp());
    }
}
