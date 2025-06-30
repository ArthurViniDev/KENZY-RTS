using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GridManager gridManager;
    [SerializeField] private GameObject mouseIndicator, cellIndicator, buildingSystem;
    [SerializeField] private Vector3 buildOffset;
    [SerializeField] private Grid grid;

    private BuildSelectionUI buildSelectionUI;
    //private Build build;
    private bool hasSelection;

    private void Awake()
    {
        buildSelectionUI = FindFirstObjectByType<BuildSelectionUI>();
    }

    private void Update()
    {
        UpdateIndicators();
        var mousePosition = gridManager.GetMouseWorldPosition();
        var gridPosition = grid.WorldToCell(mousePosition);

        mouseIndicator.transform.position = mousePosition;
        cellIndicator.transform.position = grid.CellToWorld(gridPosition);

        if (Input.GetMouseButtonDown(1) && hasSelection)
        {
            var playerResources = PlayerManager.instance.playerResources;
            var selectedBuild = buildSelectionUI.selectedBuildingPrefab;
            var buildPrice = selectedBuild.GetComponent<BaseBuild>().buildPrice;
            if (playerResources.wood < buildPrice.wood
                || playerResources.stone < buildPrice.stone
                || playerResources.food < buildPrice.food)
                return;
            BuildConstruction();
            Debug.Log("Construir");
        }
    }

    private void BuildConstruction() => Instantiate(buildSelectionUI.selectedBuildingPrefab, cellIndicator.transform.position + buildOffset, Quaternion.Euler(-90f, 0f, 0f));

    private void UpdateIndicators()
    {
        hasSelection = buildSelectionUI.selectedBuildingPrefab;
        mouseIndicator.SetActive(hasSelection);

        if (buildSelectionUI.selectedBuildingPrefab) buildSelectionUI.selectedBuildingPrefab.SetActive(true);
    }
}
