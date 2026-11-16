using System.Collections;
using UnityEngine;

public class EnemyPatrolTopDown : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    public Rigidbody2D rb;

    public GameObject player;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }
    void Update()
    {
    rb.linearVelocity = new Vector2(-player.transform.position.x * speed, -player.transform.position.y * speed);
    }
}