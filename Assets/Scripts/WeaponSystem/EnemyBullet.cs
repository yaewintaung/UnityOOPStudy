using UnityEngine;

public class EnemyBullet : Bullet
{


    public override void DealDamage(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            var player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
        }
    }
    
}
