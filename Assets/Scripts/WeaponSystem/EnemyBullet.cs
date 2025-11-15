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
                Debug.Log("Bullet Damage: " + damage);
                player.TakeDamage(damage);
            }
        }
    }
    
}
