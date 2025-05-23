using UnityEngine;

public class SelectionBuildManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("BuildSelectable"))
                {
                    IBuildSelectable buildSelectable = hit.transform.GetComponent<IBuildSelectable>();
                    bool isActive = buildSelectable.peasantBaseBuildWindow.activeSelf;

                    if (isActive) buildSelectable.OnBuildDeselect();
                    else buildSelectable.OnBuildSelect();
                }
            }
        }
    }
}
