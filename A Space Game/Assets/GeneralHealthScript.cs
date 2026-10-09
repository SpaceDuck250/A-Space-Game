using UnityEngine;
using System;

public class GeneralHealthScript : MonoBehaviour
{
    public float maxHealth;
    public float health;

    public delegate void HealthHandler(float currentHealth, float maxHealth, float changeAmount);
    public event HealthHandler OnHealthUpdate;
    public event Action OnDeath;

    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health < 0)
        {
            health = 0;
            OnDeath?.Invoke();
            return;
        }

        OnHealthUpdate(health, maxHealth, damage);
    }

    public void Heal(float amount)
    {
        health += amount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        OnHealthUpdate(health, maxHealth, amount);

    }

    public void SetHealth(float newAmount)
    {
        OnHealthUpdate(health, maxHealth, newAmount - health);


        health = newAmount;
        if (health > maxHealth)
        {
            health = maxHealth;
        }


    }
}
