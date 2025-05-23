using UnityEngine;

public class PeasantBaseBuild : MonoBehaviour, IBuildSelectable
{    
    [SerializeField] private GameObject peasantPrefab;
    [SerializeField] private GameObject peasantSpawnPoint;

    public int peasantAmount = 0;
    public int maxPeasantAmount = 2;

    public ResourceType resourceType;
    public GameObject peasantBaseBuildWindow { get; set; }

    private void Awake()
    {
        peasantBaseBuildWindow = transform.GetChild(0).gameObject;
    }

    private void Update() => AddPeasant();
    
    private void AddPeasant()
    {
        if (peasantAmount < maxPeasantAmount && PlayerManager.instance.peasantPoints > 0)
        {
            peasantPrefab.GetComponent<PeasantUnit>().resourceType = resourceType;
            peasantAmount++;
            PlayerManager.instance.peasantPoints--;
            Instantiate(peasantPrefab, peasantSpawnPoint.transform.position, Quaternion.identity);
        }
    }

    public void OnBuildSelect()
    {
        Debug.Log("Build selected: " + gameObject.name);
    }
    public  void OnBuildDeselect()
    {
        Debug.Log("Build deselected: " + gameObject.name);
    }
}
