using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public List<GameObject> selectedObjects;
    [SerializeField] private LayerMask selectableLayerMask;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, selectableLayerMask))
            {
                GameObject selectedObject = hit.collider.gameObject;
                SelectObject(selectedObject);
            }
        }
    }

    private void SelectObject(GameObject selectedObject)
    {
        if (selectedObjects.Contains(selectedObject))
        {
            DeselectObject(selectedObject);
            return;
        }
        selectedObjects.Add(selectedObject);
        selectedObject.GetComponent<ISelectable>().OnSelect();
    }

    private void DeselectObject(GameObject selectedObject)
    {
        if (!selectedObjects.Contains(selectedObject)) return;
        selectedObjects.Remove(selectedObject);
        selectedObject.GetComponent<ISelectable>().OnDeselect();
    }
}