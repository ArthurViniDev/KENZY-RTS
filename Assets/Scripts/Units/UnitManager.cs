using UnityEngine;

public class UnitManager : MonoBehaviour
{   
    [SerializeField] private LayerMask groundLayerMask;
    private SelectionManager selectionManager;
    private Camera camera1;

    private void Start()
    {
        camera1 = Camera.main;
        selectionManager = FindFirstObjectByType<SelectionManager>();
        if (selectionManager == null) Debug.LogError("SelectionManager não encontrado!");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) MovementHandler();
    }

    private void MovementHandler()
    {
        if (!camera1) return;
        var ray = camera1.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out var hit, Mathf.Infinity, groundLayerMask)) return;
        var targetPosition = hit.point;
            
        foreach (var selectedObject in selectionManager.SelectedObjects)
        {
            if (selectedObject is not BaseUnit unit) continue;
            unit.Move(targetPosition);

            if (hit.collider.gameObject.CompareTag("Target"))
            {
                unit.Target = hit.collider.gameObject;
                unit.OnAttack();
            }
            else unit.OnEndAttack();
        }
    }
}
