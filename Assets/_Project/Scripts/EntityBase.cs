using System;
using Unity.VisualScripting;
using UnityEngine;

public class EntityBase : MonoBehaviour
{
    public Entity_Profile_SO data;
    enum State
    {
        Idle,
        Walking,
        Running,
        Attacking,
        Dead
    }
    Animator _anim;
    private Rigidbody _rb;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        if (data != null)
        {
            data.currentHealth = data.maxHealth;
            data.currentStamina = data.maxStamina;           
        }

        gameObject.name = data.Name;
        
    }
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Die();
        }
    }

    private void Update()
    {
    }

    public void getOlder()
    {
        data.currentAge++;
        if (data.currentAge >= data.maxAge)
        {
            Die();
        }
    }
    
    public void TakeDamage(int damage)
    {
        data.currentHealth -= damage;
        if (data.currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(_rb, 2f);
        _anim.SetTrigger("dead");
    }
}

[CreateAssetMenu(fileName = "Entity_Name", menuName = "Entity Profile")]
public class Entity_Profile_SO : ScriptableObject
{
    [Header("Entity Information")]
    public string Name;
    public int maxAge;
    public int currentAge;

    [Header("Health")]
    public int maxHealth;
    public int currentHealth;

    [Header("Movement")]
    public float moveSpeed;
    public float runSpeed;

    [Header("Stamina")]
    public int maxStamina;
    public int currentStamina;

    [Header("Combat")]
    public int attackDamage;
    public int attackSpeed;
    public int defense;

}
