using UnityEngine;

public class FlyEnemy : Enemy
{
    [SerializeField] private float attackSpeed;
    [SerializeField] private GameObject flyBullet;
    [SerializeField] private Transform shootPoint;
    private float nextAttackTime;
    public override void Attack()
    {
        Instantiate(flyBullet, shootPoint.position,Quaternion.identity);
    }

    private void Update()
    {
        Debug.Log(distanceToPlayer.x);
        if(Mathf.Abs(distanceToPlayer.x) <= 0.1f)
        {
            if (Time.time > nextAttackTime)
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackSpeed;
            }
        }
    }




}
