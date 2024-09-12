using System;
using System.Collections.Generic;
using UnityEngine;


public class EntityManager : MonoBehaviour
{
    struct MatGroup
    {
        public Factions faction;
        public MaterialPropertyBlock materialPropertyBlock;
        public MatGroup(Factions faction, MaterialPropertyBlock materialPropertyBlock) {
            this.faction = faction;
            this.materialPropertyBlock = materialPropertyBlock;
        }
    }

    public static EntityManager inst;
    public List<ICommandComponent> commandEntities = new ();
    public List<IDamagableComponent> damagableEntities = new();
    List<MatGroup> factionAssigns = new();
    void Awake() {
        inst = this;
    }

    /// <summary>
    /// Called when the script is loaded or a value is changed in the
    /// inspector (Called in the editor only).
    /// </summary>
    void OnValidate()
    {
        inst = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void AddCommandable(ICommandComponent commandComponent) 
    {
        commandEntities.Add(commandComponent);
    }

    public void RemoveCommandable(ICommandComponent commandComponent) {
        commandEntities.Remove(commandComponent);
    }

    public void AddDamageable(IDamagableComponent damagableComponent) 
    {
        damagableEntities.Add(damagableComponent);
    }

    public void RemoveDamageable(IDamagableComponent damagableComponent) {
        damagableEntities.Remove(damagableComponent);
    }

    //Don't Request this too often
    public List<IDamagableComponent> FindVisible(Vector3 position, float gain, Factions faction) {
        List<IDamagableComponent> visible = new();
        foreach (IDamagableComponent ent in damagableEntities)
        {
            Vector3 entPosition = ent.GetPosition();
            if(faction!=ent.faction && (entPosition-position).magnitude < gain) {
                visible.Add(ent);
            }
        }
        return visible;
    }

    public void ColorShip(GameObject gameObject,Factions faction) {
        Color color = faction switch
        {
            Factions.USA => new(0, 0.987552881f, 12.95821f, 1),
            Factions.CHINA => new(12.9582138f, 0, 0, 1),
            Factions.IRAN => new(0, 12.9808674f, 0.0155171147f, 1),
            _ => new(0, 0, 0, 1),
        };
        
        bool found = false;
        foreach (MatGroup item in factionAssigns)
        {
            if(item.faction == faction) {
                foreach (Renderer mat in gameObject.GetComponentsInChildren<Renderer>()) {
                    mat.SetPropertyBlock(item.materialPropertyBlock);
                    found = true;
                }
                break;
            }
        }
        if(found) {return;}
        MatGroup temp = new(faction,new MaterialPropertyBlock());
        temp.materialPropertyBlock.SetColor("_EmissionColor",color);
        temp.materialPropertyBlock.SetColor("_BaseColor",color);
        temp.materialPropertyBlock.SetColor("BaseColor",color);
        factionAssigns.Add(temp);
    }
}
