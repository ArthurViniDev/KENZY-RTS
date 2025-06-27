using UnityEngine;

public class SelectionBuildManager : MonoBehaviour
{
    void Update() => SelectBuildWindow();

    private static void SelectBuildWindow()
    {
        if (Input.GetMouseButtonDown(1))
        {
            var mainCamera = Camera.main;

            if (!mainCamera) return;

            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit))
            {
                if (!hit.transform.CompareTag("BuildSelectable")) return;
                var buildSelectable = hit.transform.GetComponent<IBuildSelectable>();
                var isActive = buildSelectable.peasantBaseBuildWindow.activeSelf;
                if (isActive) buildSelectable.OnBuildDeselect();
                else if (PlayerManager.instance.windowsOpened == 0) buildSelectable.OnBuildSelect();
            }
        }
    }
}