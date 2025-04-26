using UnityEngine;

public class UnitManager : MonoBehaviour
{   
    [SerializeField] private LayerMask groundLayerMask;
    [SerializeField] private SelectionManager selectionManager;

    void Start()
    {
        selectionManager = FindFirstObjectByType<SelectionManager>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) MovementHandler();
    }

    private void MovementHandler()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayerMask))
        {
            Vector3 targetPosition = hit.point;
            foreach (GameObject selectedObject in selectionManager.selectedObjects)
            {
                BaseUnit unit = selectedObject.GetComponent<BaseUnit>(); 
                if (unit) unit.Move(targetPosition);
            }
        }
    }
}
