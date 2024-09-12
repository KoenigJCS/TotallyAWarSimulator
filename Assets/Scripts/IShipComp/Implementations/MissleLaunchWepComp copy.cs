using System;
using UnityEngine;

public class MissileLaunchWepComp : MonoBehaviour, IWeaponComponent
{
    public ISensorComponent sensor;
    [SerializeField] private int ammo = 20;
    [SerializeField] private float firingDelay = 2f;
    private GameObject missilePrefab;
    private float timer = 0f;
    public void Fire(IDamagableComponent target=null)
    {
        GameObject missileInst = Instantiate(missilePrefab,
        transform.position+Vector3.up*5,Quaternion.identity,WeaponManager.inst.projectileHolder);
        missileInst.GetComponent<IDamagableComponent>().faction=gameObject.GetComponent<IDamagableComponent>().faction;
        missileInst.GetComponent<IWeaponComponent>().Fire(target);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sensor = gameObject.GetComponent<ISensorComponent>();
        missilePrefab = WeaponManager.inst.GetWeaponPrefab(WeaponList.ASM);
    }

    // Update is called once per frame
    void Update()
    {
        if(ammo>0 && timer<=0) 
        {
            IDamagableComponent target = gameObject.GetComponent<ISensorComponent>().FindTarget();
            if(target != null) {
                timer = firingDelay;
                ammo--;
                Fire(target);
            }
        }
        else if(timer>0) {
            timer -= Time.deltaTime;
        }
    }
}
