using UnityEngine;

public class UnitManager : MonoBehaviour
{   
    [SerializeField] private LayerMask groundLayerMask;
    private SelectionManager selectionManager;

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
            foreach (ISelectable selectedObject in selectionManager.selectedObjects)
            {
                BaseUnit unit = (BaseUnit)selectedObject; 
                if (unit) unit.Move(targetPosition);
                if(hit.collider.gameObject.CompareTag("Target")) unit.target = hit.collider.gameObject;
                else { 
                    unit.OnEndAttack();
                }
            }
        }
    }
}
