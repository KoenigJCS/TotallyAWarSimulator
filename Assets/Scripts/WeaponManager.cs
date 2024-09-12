using System.Collections.Generic;
using UnityEngine;

public enum WeaponList
{
    ASM = 0,
    _ = -1
}
public class WeaponManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public static WeaponManager inst;
    public Transform projectileHolder;
    void Awake() {
        inst = this;
    }

    [SerializeField] private List<GameObject> weaponPrefabs = new();

    public GameObject GetWeaponPrefab(WeaponList weapon) 
    {
        return (int)weapon==-1 ? null : weaponPrefabs[(int)weapon];
    }
}
