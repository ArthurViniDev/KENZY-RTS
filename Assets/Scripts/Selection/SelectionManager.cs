using System;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject selectedObject = hit.collider.gameObject;
                SelectObject(selectedObject);
            }
        }
    }

    private void SelectObject(GameObject selectedObject)
    {
        //throw new NotImplementedException();
    }
}