using System;
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
            var selectedBuilding = buildSelectionUI.selectedBuildingPrefab;
            if (!selectedBuilding) return;
            BuildConstruction(selectedBuilding);

        }
    }

    private void BuildConstruction(GameObject build)
    {
        Instantiate(build, CursorIndicatorParent.transform.position, CursorIndicatorParent.transform.rotation);
    }
}