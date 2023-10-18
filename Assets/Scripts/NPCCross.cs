using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCross : MonoBehaviour
{
    [SerializeField] StartButton startButton;
    [SerializeField] LevelEndHandler levelEndHandler;
    [SerializeField] private int dirx;
    [SerializeField] private int diry;
    Rigidbody2D rb;

    [SerializeField] bool canCross;


    private void Start()
    {
        startButton = GameObject.Find("PlayButton").GetComponent<StartButton>();
        levelEndHandler = GameObject.Find("LevelEndHandler").GetComponent<LevelEndHandler>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (startButton.start) canCross = true;

        if (levelEndHandler.levelDone == true)
        {
            canCross = false;
            dirx = 0;
            diry = 0;
        }

        if (startButton.start && canCross == true)
        {
            rb.velocity = new Vector2(rb.velocity.x + dirx * Time.deltaTime, rb.velocity.y + diry * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        canCross = false;
        dirx = 0;
        diry = 0;

        rb.velocity = new Vector2(0, 0);
        transform.Rotate(transform.rotation.x, transform.rotation.y, Random.Range(90, 270) * (Time.deltaTime *2), Space.Self);
    }
}
