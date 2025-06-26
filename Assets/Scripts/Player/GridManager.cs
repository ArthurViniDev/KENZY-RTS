using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    private Vector3 lastPosition;
    [SerializeField] private LayerMask groundLayerMask;

    public Vector3 GetMouseWorldPosition()
    {
        var mousePosition = Input.mousePosition;
        mousePosition.z = mainCamera.nearClipPlane;
        var ray = mainCamera.ScreenPointToRay(mousePosition);
        if (Physics.Raycast(ray, out var hit, 100, groundLayerMask)) lastPosition = hit.point;

        return lastPosition;
    }
}
