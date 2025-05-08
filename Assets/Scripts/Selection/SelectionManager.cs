using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public List<ISelectable> selectedObjects = new List<ISelectable>();
    [SerializeField] private LayerMask selectableLayerMask;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit, Mathf.Infinity, selectableLayerMask))
            {
                ISelectable selectedObject = hit.collider.gameObject.GetComponent<ISelectable>();
                SelectObject(selectedObject);
            }
            else DeselectAll();
        }
    }

    private void DeselectAll()
    {
        foreach (var selectedObject in selectedObjects) selectedObject.SetSelection(false);
        
        selectedObjects.Clear();
    }

    private void SelectObject(ISelectable selectedObject)
    {
        if (Input.GetAxis("Fire3") <= 0) DeselectAll();
        
        if (selectedObjects.Contains(selectedObject)) {
            DeselectObject(selectedObject);
            return;
        }
        selectedObjects.Add(selectedObject);
        selectedObject.SetSelection(true);
    }

    private void DeselectObject(ISelectable selectedObject)
    {
        if (!selectedObjects.Contains(selectedObject)) return;
        selectedObjects.Remove(selectedObject);
        selectedObject.SetSelection(false);
    }
}