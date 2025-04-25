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
        if (selectedObjects.Contains(selectedObject)) return;
        selectedObjects.Add(selectedObject);
        selectedObject.GetComponent<ISelectable>().OnSelect();
    }
}