using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [SerializeField] private GameObject mouseIndicator, cellIndicator, buildingSystem;
    [SerializeField] private GridManager gridManager;
    [SerializeField] private Grid grid;

    private BuildSelectionUI buildSelectionUI;
    private Build build;

    private void Awake()
    {
        buildSelectionUI = FindFirstObjectByType<BuildSelectionUI>();
        build = buildingSystem.GetComponent<Build>();
    }

    private void Update()
    {
        UpdateIndicators();

        Vector3 mousePosition = gridManager.GetMouseWorldPosition();
        Vector3Int gridPosition = grid.WorldToCell(mousePosition);

        mouseIndicator.transform.position = mousePosition;
        cellIndicator.transform.position = grid.CellToWorld(gridPosition);
    }

    private void UpdateIndicators()
    {
        bool hasSelection = buildSelectionUI.selectedBuildingPrefab != null;
        build.CursorIndicatorParent.SetActive(hasSelection);

        if (buildSelectionUI.selectedBuildingPrefab != null)
            buildSelectionUI.selectedBuildingPrefab.SetActive(true);
    }
}
