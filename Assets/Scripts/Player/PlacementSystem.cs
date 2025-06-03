using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GridManager gridManager;
    [SerializeField] private GameObject mouseIndicator, cellIndicator, buildingSystem;
    [SerializeField] private Vector3 buildOffset;
    [SerializeField] private Grid grid;

    private BuildSelectionUI buildSelectionUI;
    private Build build;
    private bool hasSelection;
     
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

        if(Input.GetMouseButtonDown(1) && hasSelection)
        {
            BuildConstruction();
        }
    }

    private void BuildConstruction()
    {
        Instantiate(buildSelectionUI.selectedBuildingPrefab, cellIndicator.transform.position + buildOffset, Quaternion.Euler(-90f, 0f, 0f));
    }

    private void UpdateIndicators()
    {
        hasSelection = buildSelectionUI.selectedBuildingPrefab != null;
        build.CursorIndicatorParent.SetActive(hasSelection);
        mouseIndicator.SetActive(hasSelection);

        if (buildSelectionUI.selectedBuildingPrefab != null) buildSelectionUI.selectedBuildingPrefab.SetActive(true);
    }
}
