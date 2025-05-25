using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] GameObject mouseIndicator;
    [SerializeField] private GridManager gridManager;

    void Update()
    {
        Vector3 mousePosition = gridManager.GetMouseWorldPosition();
        mouseIndicator.transform.position = mousePosition;
    }
}
