using UnityEngine;

public class Build : MonoBehaviour
{
    private BuildSelectionUI buildSelectionUI;
    [SerializeField] private GameObject CursorIndicatorParent;

    void Awake() => buildSelectionUI = GetComponent<BuildSelectionUI>();
    void Update() => SelectBuildUI();

    private void SelectBuildUI()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GameObject selectedBuilding = buildSelectionUI.selectedBuildingPrefab;
            if (!selectedBuilding) return;
            var baseBuild = selectedBuilding.GetComponent<BaseBuild>();
            var playerResources = PlayerManager.instance.playerResources;
            if (playerResources.wood < baseBuild.buildPrice.wood ||
                playerResources.stone < baseBuild.buildPrice.stone ||
                playerResources.food < baseBuild.buildPrice.food)
            {
                return;
            }
            BuildConstruction(selectedBuilding);
        }
    }

    private void BuildConstruction(GameObject build)
    {
        BaseBuild baseBuild = build.GetComponent<BaseBuild>();
        GameObject buildCreated = Instantiate(build, CursorIndicatorParent.transform.position, CursorIndicatorParent.transform.rotation);
        buildCreated.transform.rotation = Quaternion.Euler(-90f, buildCreated.transform.rotation.eulerAngles.y, buildCreated.transform.rotation.eulerAngles.z);
        PlayerManager.instance.woodAmount -= baseBuild.buildPrice.wood;
        PlayerManager.instance.stoneAmount -= baseBuild.buildPrice.stone;
        PlayerManager.instance.foodAmount -= baseBuild.buildPrice.food;
    }
}