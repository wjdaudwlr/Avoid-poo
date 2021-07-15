using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopScript : MonoBehaviour
{

    public float PoopSpeed;
    public GameObject manager;
    private void Awake()
    {
        manager = GameObject.Find("GameManager");
    }

    void Update()
    {
        transform.Translate(0, -PoopSpeed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
            manager.GetComponent<GameManager>().ScoreAdd();
        }
        else if (collision.gameObject.tag == "Player")
        {
            manager.GetComponent<GameManager>().GameOver();
        }
    }


    
}
