using UnityEngine;

public class SelectionBuildManager : MonoBehaviour
{
    void Update() => SelectBuildWindow();

    private static void SelectBuildWindow()
    {
        if (!Input.GetMouseButtonDown(1)) return;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.CompareTag("BuildSelectable"))
            {
                IBuildSelectable buildSelectable = hit.transform.GetComponent<IBuildSelectable>();
                bool isActive = buildSelectable.peasantBaseBuildWindow.activeSelf;
                if (isActive) buildSelectable.OnBuildDeselect();
                else if (PlayerManager.instance.windowsOpened == 0) buildSelectable.OnBuildSelect();
            }
        }
    }
}
