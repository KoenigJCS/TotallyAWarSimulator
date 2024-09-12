using System;
using UnityEngine;

public class MissileWepComp : MonoBehaviour, IWeaponComponent
{
    public ISensorComponent sensor;
    public void Fire(IDamagableComponent target=null)
    {
        gameObject.GetComponent<MissileMoveComp>().target=target.GetPosition();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    //     if(sensor != null) {
    //         Fire();
    //     }
    //     else {
    //         transform.Translate(Vector3.forward);
    //     }
    }
}
