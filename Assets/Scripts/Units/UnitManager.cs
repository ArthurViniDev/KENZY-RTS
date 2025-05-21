using UnityEngine;

public class UnitManager : MonoBehaviour
{   
    [SerializeField] private LayerMask groundLayerMask;
    private SelectionManager selectionManager;

    void Start()
    {
        selectionManager = FindFirstObjectByType<SelectionManager>();
        if (selectionManager == null) Debug.LogError("SelectionManager não encontrado!");
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
            
            foreach (ISelectable selectedObject in selectionManager.SelectedObjects)
            {
                if (selectedObject is BaseUnit unit)
                {
                    unit.Move(targetPosition);

                    if (hit.collider.gameObject.CompareTag("Target"))
                    {
                        unit.target = hit.collider.gameObject;
                        unit.OnAttack();
                    }
                    else unit.OnEndAttack();
                }
            }
        }
    }
}
