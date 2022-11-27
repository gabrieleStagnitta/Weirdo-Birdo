using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class birdoManager : MonoBehaviour
{
    public int hearths = 3;
    [SerializeField] private Animator animator;
    public float points = 0f;
    public bool isPlaying = false;
    
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject UI;
    [SerializeField] private GameObject startUI;
    [SerializeField] private TextMeshProUGUI _point;
    [SerializeField] private TextMeshProUGUI _life;

    [SerializeField] private GameObject spawner;
    

    private void Awake()
    {
        myStart();
    }


    private void myStart()
    {
        animator = this.gameObject.GetComponent<Animator>();
        gameOverUI = GameObject.Find("Canvas").transform.Find("GameOver").gameObject;
        UI = GameObject.Find("Canvas").transform.Find("UI").gameObject;
        startUI = GameObject.Find("Canvas").transform.Find("Start UI").gameObject;
        _life = UI.transform.Find("Life").GetComponent<TextMeshProUGUI>();
        _point = UI.transform.Find("Points").GetComponent<TextMeshProUGUI>();

        _life.text = hearths.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        makeAJump();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacles"))
        {
            hitted();
        }
        else if(collision.CompareTag("Point"))
        {
            points+=1f;
            _point.text = points.ToString();
        }
    }

    private void makeAJump()
    {
        this.gameObject.GetComponent<movementBirdo>().jump();
    }

    private void hitted()
    {
        hearths--;
        _life.text = hearths.ToString();
        if (hearths == 0)
        {
            gameOver();
        }
        else
        {
            animator.SetTrigger("hitted");
        }
    }

    private void gameOver()
    {
        gameOverUI.SetActive(true);
        Destroy(this.gameObject);
    }

    public void startGame()
    {
        myStart();
        isPlaying = true;
        animator.SetTrigger("startGame");
        UI.SetActive(true);
        startUI.SetActive(false);
        //Instantiate(spawner);
        this.gameObject.AddComponent<movementBirdo>();
        this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1.7f;
        this.gameObject.GetComponent<movementBirdo>().velocity = 8;
        gameOverUI.SetActive(false);
    }

}
