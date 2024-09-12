using UnityEngine;

public enum Factions
{
    USA,
    CHINA,
    IRAN,
}

public interface IDamagableComponent
{
    float health { get; set; }
    float hardness { get; set; }
    Factions faction { get; set; }
    void TakeDamage(int damageValue);
    // This reduces crit chance
    void Die();
    Vector3 GetPosition();
}
