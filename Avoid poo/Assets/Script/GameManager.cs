using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject obj;
    public PoopScript poop;
    public GameObject gameoverUI;
    public Text ScoreText;

    public float SpawnSpeed;
    public int Score = 0;

    private void Awake()
    {
        poop = GetComponent<PoopScript>();
        SpawnSpeed = 0.3f;
    }

    void Start()
    {
        Score = 0;
        ScoreText.text = "Score : " + Score.ToString();
        Invoke("Spawn", 3);
    }

    public void Spawn()
    {
        if(Score > 500)
        {
            SpawnSpeed = 0.2f;
        }
        Instantiate(obj, new Vector3(Random.Range(-8.8f, 8.9f), 5, 0), Quaternion.identity);
        Invoke("Spawn", SpawnSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameOver();
        }
    }

    public void ReStart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        GameObject.Find("Canvas").transform.Find("GameOverUI").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("ScoreText").gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    public void ScoreAdd()
    {
        Score += 10;
        ScoreText.text = "Score : " + Score.ToString();
    }
}

