using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float stopDistance = 0.1f;

    private Player player;
    private Rigidbody2D rb;
    protected Vector2 distanceToPlayer;

    private void Start()
    {
        player = GameManager.Instance.GetActivePlayer();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Move();
    }


    public abstract void Attack();

    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GameManager.Instance.SetEnemyCount(GameManager.Instance.GetEnemyCouont() - 1);
            Destroy(gameObject,0.05f);
        }
    }

    public virtual void Move()
    {
        if(player != null)
        {
            var dir = player.transform.position - transform.position;
            distanceToPlayer = dir;
            if (dir.magnitude > stopDistance) rb.linearVelocityX = dir.x * moveSpeed * Time.deltaTime;
        }
    }


}
