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
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayerMask))
            {
                Debug.Log("Right mouse button clicked on ground: " + hit.point);
                Vector3 targetPosition = hit.point;
                foreach (GameObject selectedObject in selectionManager.selectedObjects)
                {
                    BaseUnit unit = selectedObject.GetComponent<BaseUnit>();
                    if (unit) unit.Move(targetPosition);
                }
            }
        }
    }
}
