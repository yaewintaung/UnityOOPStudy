using UnityEngine;

public class RangeEnemy : Enemy
{
    [SerializeField] private float range;
    [SerializeField] private float attackSpeed;
    [SerializeField] private Weapon weapon;
    [SerializeField] private Transform weaponHolder;

    private float nextAttackTime;

    public override void Attack()
    {
        if (weapon != null)
        {
            if(weapon.GetCurrentAmmo() > 0)
            {
                weapon.Fire();
            }
            else
            {
                weapon.Reload();
            }
        }
    }

    private void Update()
    {
        weaponHolder.transform.position = transform.position;
        if (distanceToPlayer.magnitude <= range)
        {
            var angle = Mathf.Atan2 (distanceToPlayer.y, distanceToPlayer.x) * Mathf.Rad2Deg;
            weaponHolder.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
            if(Time.time > nextAttackTime)
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackSpeed;
            }
        }
    }




}
