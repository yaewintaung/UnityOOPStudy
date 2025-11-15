using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponHolder : MonoBehaviour
{
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
            return transform.GetChild(0).GetComponent<Weapon>();
        }

        return null;
    }
}
