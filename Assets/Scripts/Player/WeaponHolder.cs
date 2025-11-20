using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private Transform weaponHoldPoint;
    private void Update()
    {
        if(Mouse.current != null)
        {
            Vector3 mouseScreenPos = Mouse.current.position.ReadValue();
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
            mouseWorldPos.z = 0;
            var dir = mouseWorldPos - transform.position;
            var angle = Mathf.Atan2 (dir.y,dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);
        }   
        transform.position = transform.parent.position;
    }

    public Weapon GetWeapon()
    {
        if(transform.parent != null)
        {
            return weaponHoldPoint.GetChild(0).GetComponent<Weapon>();
        }

        return null;
    }

    public void SwitchWeapon(Weapon newWeapon)
    {
        if (weaponHoldPoint.GetChild(0).TryGetComponent<Weapon>(out Weapon weapon))
        {
            weapon.transform.SetParent(null);
            weapon.gameObject.SetActive(false);
        }
        if (newWeapon != null)
        {
            newWeapon.gameObject.SetActive(true);
            newWeapon.transform.SetParent(weaponHoldPoint);
            newWeapon.transform.localPosition = Vector3.zero;
            newWeapon.transform.localRotation = Quaternion.identity;
            
        }
        
        


    }
}
