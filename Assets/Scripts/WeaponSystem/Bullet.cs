using UnityEngine;

public class Bullet : MonoBehaviour
{
  

    [SerializeField] private float speed = 5f;
    [SerializeField] private float lifeTime = 5f;
    

    private Rigidbody2D rb;
    protected int damage;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
        Destroy(gameObject,lifeTime);
    }

    void Update()
    {
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DealDamage(collision);
        Destroy(gameObject);
    }

    public virtual void DealDamage(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            var enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                Debug.Log("Bullet Damage: " + damage);
                enemy.TakeDamage(damage);
            }
        }
    }

    public void SetDamage(int dmg)
    {
        damage = dmg;
    }
}
