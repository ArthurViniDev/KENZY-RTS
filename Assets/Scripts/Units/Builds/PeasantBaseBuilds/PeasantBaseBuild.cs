using UnityEngine;

public class PeasantBaseBuild : MonoBehaviour
{
    [SerializeField] private GameObject peasantPrefab;
    [SerializeField] private GameObject peasantSpawnPoint;
    public ResourceType resourceType;
    public int peasantAmount = 0;
    public int maxPeasantAmount = 2;

    void Update()
    {
        AddPeasant();
    }
    
    public void AddPeasant()
    {
        if (peasantAmount < maxPeasantAmount && PlayerManager.instance.peasantPoints > 0)
        {
            peasantAmount++;
            PlayerManager.instance.peasantPoints--;
            Instantiate(peasantPrefab, peasantSpawnPoint.transform.position, Quaternion.identity);
        }
    }
}
