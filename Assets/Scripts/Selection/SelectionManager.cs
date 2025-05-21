using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public readonly List<ISelectable> SelectedObjects = new List<ISelectable>();
    [SerializeField] private LayerMask selectableLayerMask;
    private Camera camera1;

    private const string DeselectButton = "Fire3";

    private void Start() => camera1 = Camera.main;
    

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) SelectionHandler();
    }

    private void SelectionHandler()
    {
        if (!camera1) return;
        var ray = camera1.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit, Mathf.Infinity, selectableLayerMask))
        {
            var selectedObject = hit.collider.gameObject.GetComponent<ISelectable>();
            if (selectedObject == null) return;
            SelectObject(selectedObject);
        }
        else DeselectAll();
    }

    private void DeselectAll()
    {
        foreach (var selectedObject in SelectedObjects) selectedObject.SetSelection(false);
        
        SelectedObjects.Clear();
    }

    private void SelectObject(ISelectable selectedObject)
    {
        if (SelectedObjects.Contains(selectedObject))
        {
            DeselectObject(selectedObject);
            return;
        }

        if (Input.GetAxis(DeselectButton) <= 0) DeselectAll();

        SelectedObjects.Add(selectedObject);
        selectedObject.SetSelection(true);
    }

    private void DeselectObject(ISelectable selectedObject)
    {
        if (!SelectedObjects.Contains(selectedObject)) return;
        SelectedObjects.Remove(selectedObject);
        selectedObject.SetSelection(false);
    }
}