using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EntityBase : MonoBehaviour
{
    public Entity_Profile_SO data;
    private StateMachine _stateMachine;
    Animator _anim;
    private Rigidbody _rb;
    private void Start()
    {
        _stateMachine = GetComponent<StateMachine>();
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();

        data.currentHealth = data.maxHealth;
        data.currentStamina = data.maxStamina;           
        gameObject.name = data.Name;
        
    }

    public void Heal(int amount, float delay)
    {
        StartCoroutine(HealingCoroutine(amount, delay));
    }
    public void TakeDamage(int damage)
    {
        data.currentHealth -= damage;
        if (data.currentHealth <= 0)
        {
            Die();
        }
    }

    public void IncreaseStamina(int amount, float delay)
    {
        StartCoroutine(StaminaCoroutine(amount, delay));
    }
    public void DecreaseStamina(int amount)
    {
        data.currentStamina -= amount;
        if (data.currentStamina <= 0)
        {
            data.currentStamina = 0;
        }
    }

    public void Die()
    {
        _stateMachine.ChangeState(StateMachine.State.Dead);
        _anim.SetBool("dead", true);
    }

    private IEnumerator HealingCoroutine(int amount, float delay)
    {
        yield return new WaitForSeconds(delay);

        data.currentHealth = Mathf.Min(data.maxHealth, data.currentHealth + amount);
    }

    private IEnumerator StaminaCoroutine(int amount, float delay)
    {
        yield return new WaitForSeconds(delay);

        data.currentStamina = Mathf.Min(data.maxStamina, data.currentStamina + amount);
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
