using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public event Action ChangeHealth;

    public float CurrentHealth { get; private set; }
    public float MaxHealth { get; private set; } = 100;

    private void Awake()
    {
        CurrentHealth = MaxHealth;
    }

    public void SetCurrentHealth(float health) => CurrentHealth = health;

    public void TakeDamage(float damageValue)
    {
        SetCurrentHealth(Mathf.Clamp(CurrentHealth - damageValue, 0, MaxHealth));
        ChangeHealth?.Invoke();
    }

    public void TakeHeal(float healValue)
    {
        SetCurrentHealth(Mathf.Clamp(CurrentHealth + healValue, 0, MaxHealth));
        ChangeHealth?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out MedicalKit medikalKit))
        {
            if(CurrentHealth < MaxHealth)
            {
                TakeHeal(medikalKit.HealValue);
                medikalKit.gameObject.SetActive(false);
            }
        }

        if (collision.gameObject.TryGetComponent(out Platform platform))
            this.transform.SetParent(collision.transform);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform platform))
            this.transform.SetParent(null);
    }
}