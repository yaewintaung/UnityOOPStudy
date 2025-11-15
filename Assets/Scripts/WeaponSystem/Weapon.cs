using UnityEngine;

public class Weapon : MonoBehaviour
{


    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletPoint;

    [SerializeField] private int damage;
    [SerializeField] private int fireRate;
    [SerializeField] private int ammo;


    private int currentAmmo;


    private void Start()
    {
        currentAmmo = ammo;
    }

    public void Fire()
    {
        var bul = Instantiate(bullet, bulletPoint.position, transform.rotation);
        bul.GetComponent<Bullet>().SetDamage(damage);
        currentAmmo -= 1;

    }

    public void Reload()
    {
        currentAmmo = ammo;
    }

    public int GetCurrentAmmo()
    {
        return currentAmmo;
    }


}
