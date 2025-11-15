using UnityEngine;

public class FlyBullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            var player = collision.collider.GetComponent<Player>();
            player.TakeDamage(4);
            
        }
        Destroy(gameObject);
    }
}
