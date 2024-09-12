using System.Collections.Generic;
using UnityEngine;

public class BasicSensorComp : MonoBehaviour, ISensorComponent
{
    public float gain;

    public bool isActive = true;

    public IDamagableComponent FindTarget()
    {
        IDamagableComponent myTarget = null;
        List<IDamagableComponent> targets = EntityManager.inst.FindVisible(transform.position,gain,GetComponent<IDamagableComponent>().faction);
        Debug.Log("Searching!");
        //Target the biggest
        float maxHardness = -999;
        foreach (IDamagableComponent target in targets) {
            if (target.hardness>maxHardness) {
                myTarget = target;
                maxHardness = target.hardness;
            }
        }
        return myTarget;
    }

    // System.Numerics.Vector3 ISensorComponent.target { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
