using UnityEngine;

public class MeleeEnemy : Enemy
{

    public override void Attack()
    {
        Debug.Log("melee attack");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            Attack();
        }
    }


}
