using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    public float deltaV;
    public static ControlManager inst;
    public GameObject target;
    bool newTarget = false;
    RaycastHit hit;
    void Awake()
    {
        inst = this;
    }

    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            int watermask = 1<<4;
            if(Physics.Raycast(ray, out hit, 6000f, watermask))
            {
                newTarget=true;
            }
        }
        for(int i = 0; i<SelectionManager.inst.selectedCommandables.Count; i++)
        {
            ICommandComponent selectedEntity = SelectionManager.inst.selectedCommandables[i];
            
            if(newTarget && Input.GetKey(KeyCode.LeftControl))
            {
                selectedEntity.AddOrder(new(0,hit.point));
            }
            else if(newTarget)
            {
                selectedEntity.Stop();
                selectedEntity.AddOrder(new(0,hit.point));
            }
            
        }
        newTarget=false;        
    }

    public void CreatePoints(float px, float pz, int radius, Color color)
    {
        float x;
        //float y;
        float z;
        int segments = 10;
        List<Vector3> points = new List<Vector3>();
        float angle = 20f;

        for(int i = 0; i< (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius + px;
            z = Mathf.Cos(Mathf.Deg2Rad * angle) * radius + pz;
            points.Add(new Vector3(x,30,z));
            angle += (360f / segments);
            
        }
        for(int i = 0; i<points.Count-1; i++) 
        {
            Debug.DrawLine(points[i], points[i+1], color);
        }
    }

    
}
