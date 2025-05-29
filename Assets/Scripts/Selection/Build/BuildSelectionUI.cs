using UnityEngine;

public class BuildSelectionUI : MonoBehaviour
{
    public GameObject[] buildingPrefabs; // Array of building prefabs to select from, will be set in the inspector
    public GameObject selectedBuildingPrefab; // The currently selected building prefab

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            selectedBuildingPrefab = null; // Deselect the building when Escape is pressed
        }
    }

    public void SelectStablePrefab() => selectedBuildingPrefab = buildingPrefabs[0];
}