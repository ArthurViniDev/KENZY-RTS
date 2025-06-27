using System.Collections;
using UnityEngine;

public class PeasantBaseBuild : MonoBehaviour, IBuildSelectable
{
    [SerializeField] private GameObject peasantPrefab;
    [SerializeField] private GameObject peasantSpawnPoint;
    private int playerWindowsOpened;
    public int peasantAmount = 0;
    public int maxPeasantAmount = 2;
    public bool canOpenWindow = false;

    public Stable stable;
    public ResourceType resourceType;
    public GameObject peasantBaseBuildWindow { get; set; }


    private void Awake() => peasantBaseBuildWindow = transform.GetChild(0).gameObject;

    private void Update() => AddPeasant();

    void Start()
    {
        stable = GetComponent<Stable>();
        StartCoroutine(OpenableWindow());
        playerWindowsOpened = PlayerManager.instance.windowsOpened;
    }

    public void SellBuild()
    {
        int[] SplitValuesInHalf(int n1, int n2, int n3) => new int[] { Mathf.Abs(n1 / 2), Mathf.Abs(n2 / 2), Mathf.Abs(n3 / 2) };
        int[] refund = SplitValuesInHalf(stable.buildPrice.wood, stable.buildPrice.stone, stable.buildPrice.food);
        PlayerManager.instance.RefundResources(refund[0], refund[1], refund[2]);
        DestroyImmediate(gameObject);
    }

    private IEnumerator OpenableWindow()
    {
        yield return new WaitForSeconds(0.2f);
        canOpenWindow = true;
    }
    public void OnBuildSelect()
    {
        if (!canOpenWindow) return;
        else if (playerWindowsOpened != 0) return;
        playerWindowsOpened++;
        peasantBaseBuildWindow.gameObject.SetActive(true);
    }
    public void OnBuildDeselect()
    {
        if (!canOpenWindow) return;
        playerWindowsOpened--;
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
