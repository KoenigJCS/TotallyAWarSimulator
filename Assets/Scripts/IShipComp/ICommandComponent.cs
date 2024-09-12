using UnityEngine;

public struct Order
{
    public int orderType;
    public Vector3 orderCenter;

    public Order(int orderType, Vector3 orderCenter) {
        this.orderType = orderType;
        this.orderCenter = orderCenter;
    }
}

public interface ICommandComponent
{
    bool isSelected {get;set;} 

    void AddOrder(Order newOrder);

    void Stop();
}