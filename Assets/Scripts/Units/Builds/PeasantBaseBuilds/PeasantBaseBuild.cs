using System.Collections;
using UnityEngine;

public class PeasantBaseBuild : MonoBehaviour, IBuildSelectable
{
    [SerializeField] private GameObject peasantPrefab;
    [SerializeField] private GameObject peasantSpawnPoint;

    public int peasantAmount = 0;
    public int maxPeasantAmount = 2;
    public bool canOpenWindow = false;

    public ResourceType resourceType;
    public GameObject peasantBaseBuildWindow { get; set; }

    private void Awake() => peasantBaseBuildWindow = transform.GetChild(0).gameObject;
    private void Update() => AddPeasant();
    public void SellBuild() {/* Implement sell build logic here */}

    void Start() => StartCoroutine(OpenableWindow());

    private IEnumerator OpenableWindow()
    {
        yield return new WaitForSeconds(0.2f);
        canOpenWindow = true;
    }
    public void OnBuildSelect()
    {
        if (!canOpenWindow) return;
        peasantBaseBuildWindow.gameObject.SetActive(true);
    }
    public void OnBuildDeselect()
    {
        if (!canOpenWindow) return;
        peasantBaseBuildWindow.SetActive(false);
    }

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
}
