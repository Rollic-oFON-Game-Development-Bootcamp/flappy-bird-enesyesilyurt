using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Bird : MonoSingleton<Bird>
{
    [SerializeField] private float force = 100;
    [SerializeField] private float rotate;
    private Rigidbody2D rigidbody2d;
    public event Action BirdDie;

    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        rigidbody2d.gravityScale = 0;
        GameController.Instance.StartGame += OnStartGame;
    }

    private void Update()
    {
        if (GameController.Instance.IsGameStart)
        {
            Movement();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!other.GetComponent<Pipe>())
        {
            BirdDie?.Invoke();
            GameController.Instance.IsGameStart = false;
            rigidbody2d.gravityScale = 0;
        }
        else
        {
            ScoreController.Instance.Increase();
        }
    }

    public void OnStartGame()
    {
        GameController.Instance.IsGameStart = true;
        rigidbody2d.gravityScale = 1;
        Jump();
    }

    private void Movement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
        else
        {
            transform.eulerAngles -= new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, rotate);
        }
    }
    private void Jump()
    {
        rigidbody2d.velocity = Vector2.zero;
        rigidbody2d.AddForce(Vector2.up * force, ForceMode2D.Force);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 35.0f);
    }
}
