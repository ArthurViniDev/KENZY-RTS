using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    private Vector3 lastPosition;
    [SerializeField] private LayerMask groundLayerMask;

    public Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = mainCamera.nearClipPlane;
        Ray ray = mainCamera.ScreenPointToRay(mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, groundLayerMask)) lastPosition = hit.point;

        return lastPosition;
    }
}
