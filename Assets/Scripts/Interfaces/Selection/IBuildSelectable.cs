using UnityEngine;

public interface IBuildSelectable
{
    public GameObject peasantBaseBuildWindow { get; set; }
    public void OnBuildSelect();
    public void OnBuildDeselect();
}

