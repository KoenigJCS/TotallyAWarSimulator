using Unity.VisualScripting;
using UnityEngine;

public enum MissilePhases
{
    LAUNCH,
    CRUSE,
    TERMINAL
}

public interface IWeaponComponent
{
    void Fire(IDamagableComponent target=null);
}
