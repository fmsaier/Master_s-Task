using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FGameManager : MonoBehaviour
{
    public static FGameManager Instance;
    public bool gameStart = false;
    public bool isPausing = false;
    float blockTimer = 0;
    float helpTimer = 0;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        gameStart = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }

        if (gameStart)
        {
            blockTimer += Time.deltaTime;
            helpTimer += Time.deltaTime;
            if (blockTimer > 0.4f)
            {
                blockTimer = 0;
                GameObject first = Instantiate(FResourceManager.Instance.Block, new Vector3(9.5f, 5f + Random.Range(-1, 1), 0), Quaternion.identity);
                Instantiate(FResourceManager.Instance.Block, new Vector3(9.5f, first.transform.position.y - 10 + Random.Range(-0.3f, 0.3f), 0), Quaternion.identity);
            }
            if (helpTimer > 5)
            {
                helpTimer = 0;
                int number = Random.Range(0, 100);
                if (number >= 0 && number <= 20)
                {
                    GameObject vegetable;
                    if (number % 2 == 0)
                        vegetable = Instantiate(FResourceManager.Instance.Vegetable, new Vector3(9.5f, Random.Range(1.5f, 3), 0), Quaternion.identity);
                    else
                        vegetable = Instantiate(FResourceManager.Instance.Vegetable, new Vector3(9.5f, -Random.Range(1.5f, 3), 0), Quaternion.identity);
                    vegetable.GetComponent<Rigidbody2D>().velocity = new Vector3(-4, 0, 0);
                }
            }
        }
    }

    public void Pause()
    {
        if (!isPausing)
        {
            isPausing = true;
            FResourceManager.Instance.PauseTips.SetActive(true);
            FResourceManager.Instance.Pause.enabled = true;
            Time.timeScale = 0;
        }
        else
        {
            isPausing = false;
            FResourceManager.Instance.PauseTips.SetActive(false);
            FResourceManager.Instance.Pause.enabled = false;
            Time.timeScale = 1;
        }
    }

    public void Shoot(GameObject gameObject)
    {
        GameObject bullet = Instantiate(gameObject, new Vector3(9.5f, Random.Range(-1.5f, 1.5f), 0), gameObject.transform.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(-5, 0, 0);
    }

    public void Init()
    {

    }

}
