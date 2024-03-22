using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPlayerController : MonoBehaviour
{
    bool isJumping = false;
    int pillCount = 100;
    float jumpTimer = 0;
    float fallTimer = 0;
    float shootTimer = 0;
    private void Start()
    {

    }
    private void Update()
    {
        jumpTimer -= Time.deltaTime;
        fallTimer -= Time.deltaTime;
        shootTimer -= Time.deltaTime;
        FResourceManager.Instance.UpCDMask.fillAmount = 6.67f * jumpTimer;
        FResourceManager.Instance.DownCDMask.fillAmount = 6.67f * fallTimer;
        FResourceManager.Instance.ShootCDMask.fillAmount = 2f * shootTimer;
        if (!isJumping)
        {
            transform.Translate(new Vector3(0, -5 * Time.deltaTime, 0));
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
            StartJump();
        if (Input.GetKeyDown(KeyCode.S))
            StartFall();
        if (Input.GetKeyDown(KeyCode.J))
            Shoot();
    }
    public void StartJump()
    {
        if (jumpTimer <= 0 && !isJumping)
        {
            StartCoroutine(Jump());
        }
    }

    public void StartFall()
    {
        if (fallTimer <= 0 && !isJumping)
        {
            StartCoroutine(Fall());
        }
    }

    public IEnumerator Jump()
    {
        isJumping = true;
        float timer = 0;
        jumpTimer = 0.15f;
        while (timer < 0.05f)
        {
            transform.Translate(new Vector3(0, 30 * Time.deltaTime, 0));
            timer += Time.deltaTime;
            yield return null;
        }
        isJumping = false;
    }

    public IEnumerator Fall()
    {
        isJumping = true;
        float timer = 0;
        fallTimer = 0.15f;
        while (timer < 0.05f)
        {
            transform.Translate(new Vector3(0, -30 * Time.deltaTime, 0));
            timer += Time.deltaTime;
            yield return null;
        }
        isJumping = false;
    }

    public void Shoot()
    {
        if (pillCount > 0 && shootTimer <= 0)
        {
            shootTimer = 0.5f;
            pillCount--;
            FResourceManager.Instance.PillCount.text = pillCount.ToString();
            GameObject bullet = Instantiate(FResourceManager.Instance.Pill, transform.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(5, 0, 0);
        }
    }

    public void AddPill(int number)
    {
        pillCount += number;
        FResourceManager.Instance.PillCount.text = pillCount.ToString();
    }
}
