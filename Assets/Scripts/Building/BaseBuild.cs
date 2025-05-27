using UnityEngine;



public class BaseBuild : MonoBehaviour
{
    [HideInInspector] public float buildTime = 5f;
    public GameObject buildingPrefab;
    public Resources buildPrice;
}
