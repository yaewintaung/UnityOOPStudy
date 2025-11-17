using System;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{

    public event EventHandler<OnPlyerHealthUpdateEventArgs> OnPlyerHealthUpdate;
    public class OnPlyerHealthUpdateEventArgs
    {
        public int playerHealth; 
    }

    [SerializeField] private float jumpForce = 7f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private WeaponHolder weaponHolder;
    [SerializeField] private Transform groundPoint;
    [SerializeField] private float groundCheckRadius = .5f;
    [SerializeField] private int maxHealth = 30;

    private Rigidbody2D rb;
    private Vector2 inputVector;
    private Weapon weapon;
    private int health = 30;
    private float baseSpeed = 5f;

    private Weapon tempWeapon;
    private float shieldEffect = 0f;


    void Start()
    {
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        GameInput.Instance.OnAttackClick += GameInput_OnAttackClick;
        GameInput.Instance.OnJumpClick += GameInput_OnJumpClick;
        GameInput.Instance.OnReloadClick += GameInput_OnReloadClick;
        if (weaponHolder.GetWeapon() != null)
        {
            weapon = weaponHolder.GetWeapon();
        }
    }

    private void GameInput_OnReloadClick(object sender, System.EventArgs e)
    {
        if(weapon != null)
        {
            weapon.Reload();
            UIManager.Instance.UpdateAmmoText(weapon.GetCurrentAmmo());
        }
    }

    private void GameInput_OnJumpClick(object sender, System.EventArgs e)
    {
        if(Physics2D.OverlapCircle(groundPoint.position,groundCheckRadius, LayerMask.GetMask("Ground")))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }



    private void GameInput_OnAttackClick(object sender, System.EventArgs e)
    {
        if(weapon != null)
        {
            if(weapon.GetCurrentAmmo() > 0)
            {
                weapon.Fire();
                UIManager.Instance.UpdateAmmoText(weapon.GetCurrentAmmo());
            }
            else
            {
                UIManager.Instance.ShowRToReload();
            }
        }
    }

    void Update()
    {
        inputVector = GameInput.Instance.GetInputVectorNormalized();
        
    }


    private void FixedUpdate()
    {
        rb.linearVelocityX = inputVector.x * speed;
    }



    public void TakeDamage(int damage)
    {
        health -= damage;
        OnPlyerHealthUpdate?.Invoke(this, new OnPlyerHealthUpdateEventArgs
        {
            playerHealth = health,
        });
        if (health <= 0)
        {
            Debug.Log("Plaer die");
        }
    }



    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<IInteractable>(out IInteractable interactable))
        {
            if (interactable is IHealable healable)
            {
                if (health < maxHealth)
                {
                    health += healable.GetHealAmount();
                    OnPlyerHealthUpdate?.Invoke(this, new OnPlyerHealthUpdateEventArgs
                    {
                        playerHealth = health
                    });
                    interactable.Interact();
                }
            }
            else if (interactable is IDamageable damageable)
            {
                TakeDamage(damageable.GetDamageAmount());
                OnPlyerHealthUpdate?.Invoke(this, new OnPlyerHealthUpdateEventArgs
                {
                    playerHealth = health
                });
                interactable.Interact();
            }
            
        }
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public int GetCurrentHealth()
    {
        return health;
    }

    public void SetShield(float shield)
    {
        shieldEffect = shield;
    }

    public void EquipTemporyWeapon(Weapon weapon)
    {
        tempWeapon = weapon;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public float GetSpeed()
    {
        return baseSpeed;
    }
}
