using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager inst;
    public int selectedIndex = 0;
    public ICommandComponent selectedEntity;
    bool isSelecting = false;
    Vector3 mousePos1;

    public List<ICommandComponent> selectedCommandables = new();
    private void Awake() {
        inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Tab))
        {
            SelectNextEnt();
        }

        //Selecting
        if(Input.GetMouseButtonDown(0))
        {
            UnselectAll();
            isSelecting = true;
            mousePos1 = Input.mousePosition;
        }
        if(Input.GetMouseButtonUp(0))
        {
            selectedCommandables.Clear();
            foreach(ICommandComponent ent in EntityManager.inst.commandEntities)
            {
                if(InSelectedZone(ent.ConvertTo<GameObject>().transform.position))
                {
                    selectedCommandables.Add(ent);
                    ent.isSelected = true;
                }
            }
            mousePos1 = Input.mousePosition;
            isSelecting = false;
        }
    }

    void OnGUI() 
    {
        if(isSelecting)
        {
            Rect rect = Utilties.GetScreenRect(mousePos1, Input.mousePosition);
            Utilties.DrawScreenRect(rect, new Color(0.8f, 0.8f, 0.95f, 0.25f));
            Utilties.DrawScreenBorder(rect, 2, new Color(0.8f, 0.8f, 0.95f));
        }
    }

    void SelectNextEnt()
    {
        selectedIndex = (selectedIndex >= EntityManager.inst.commandEntities.Count - 1 ? 0 : selectedIndex + 1);
        selectedEntity = EntityManager.inst.commandEntities[selectedIndex];
        UnselectAll();
        selectedEntity.isSelected = true;
        selectedCommandables.Add(selectedEntity);
    }

    void UnselectAll()
    {
        foreach(ICommandComponent phx in EntityManager.inst.commandEntities)
        {
            phx.isSelected = false;
        }
    }

    bool InSelectedZone(Vector3 position)
    {
        if(!isSelecting)
            return false;
        var camera = Camera.main;
        var viewportBounds = Utilties.GetViewportBounds(camera, mousePos1, Input.mousePosition);
        return viewportBounds.Contains(camera.WorldToViewportPoint(position));
    }
}
