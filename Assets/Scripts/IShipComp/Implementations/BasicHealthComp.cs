using System;
using Unity.VisualScripting;
using UnityEngine;

public class BasicHealthComp : MonoBehaviour, IDamagableComponent
{
    [SerializeField] private float _health;    
    public float health { get => _health; set => _health = value ; }
    [SerializeField] private float _hardness;    
    public float hardness { get => _hardness; set => _hardness = value ; }
    [SerializeField] private Factions _faction = Factions.USA;    
    public Factions faction { get => _faction; set => _faction = value ; }

    public void TakeDamage(int damageValue)
    {
        throw new NotImplementedException();
    }

    public void Die() 
    {
        ICommandComponent command =  gameObject.GetComponent<ICommandComponent>();
        if(command != null) 
        {
            EntityManager.inst.RemoveCommandable(command);
        } 
        EntityManager.inst.RemoveDamageable(this);
        Destroy(gameObject);
    }

    public Vector3 GetPosition() {
        return gameObject.transform.position;
    }

    void Start()
    {
        EntityManager.inst.AddDamageable(this);
        EntityManager.inst.ColorShip(gameObject,faction);
    }

    /// <summary>
    /// Called when the script is loaded or a value is changed in the
    /// inspector (Called in the editor only).
    /// </summary>
    void OnValidate()
    {
        if(EntityManager.inst) 
        {
            EntityManager.inst.ColorShip(gameObject,faction);
        }
    }

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        if(EntityManager.inst) 
        {
            EntityManager.inst.ColorShip(gameObject,faction);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
