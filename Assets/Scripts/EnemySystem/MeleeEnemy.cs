using UnityEngine;

public class MeleeEnemy : Enemy
{

    public override void Attack()
    {
        GameManager.Instance.GetActivePlayer().TakeDamage(1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            Attack();
        }
    }


}
