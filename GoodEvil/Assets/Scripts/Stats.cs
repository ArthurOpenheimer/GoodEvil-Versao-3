using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [Header("Health")]
    public float currentHealth;
    public float maxHealth;
    public float regenHealth;

    [Header("Mana")]
    public float currentMana;
    public float maxMana;
    public float regenMana;

    [Header("Stamina")]
    public float currentStamina;
    public float maxStamina;

    [Header("Stats")]
    public float speed = 5;
    public int power;
    public int intelligence;
    public int defense;
    public int level;
    public int xp;

    private void Start()
    {
        InvokeRepeating("RegenerateMana", 0.0f, regenMana);
        InvokeRepeating("RegenerateHealth", 0.0f, regenHealth);
    }

    private void RegenerateMana()
    {
        if (currentMana > maxMana) return;

        currentMana++;
    }

    private void RegenerateHealth()
    {
        if (currentHealth > maxHealth) return;

        currentHealth++;
    }

    public void Damage(float value)
    {
        currentHealth -= value;

        if (currentHealth < 0) currentHealth = 0;
    }

    public void Heal(float value)
    {
        currentHealth += value;

        if (currentHealth > maxHealth) currentHealth = maxHealth;
    }
    public void ReduceMana(float value)
    {
        currentHealth -= value;

        if (currentMana < 0) currentMana = 0;
    }

}

