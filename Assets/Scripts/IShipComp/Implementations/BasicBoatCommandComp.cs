using UnityEngine;

public class BasicBoatCommandComp : MonoBehaviour, ICommandComponent
{
    [SerializeField] private bool _isSelected;
    public bool isSelected { get => _isSelected; set =>_isSelected = value ;}

    public void AddOrder(Order newOrder)
    {
        throw new System.NotImplementedException();
    }

    public void Stop()
    {
        throw new System.NotImplementedException();
    }

    void Start()
    {
        EntityManager.inst.AddCommandable(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}