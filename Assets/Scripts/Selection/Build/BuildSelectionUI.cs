using UnityEngine;

public class BuildSelectionUI : MonoBehaviour
{
    public GameObject[] buildingPrefabs; // Array of building prefabs to select from, will be set in the inspector
    public GameObject selectedBuildingPrefab; // The currently selected building prefab

    public void selectStablePrefab() => selectedBuildingPrefab = buildingPrefabs[0];
}