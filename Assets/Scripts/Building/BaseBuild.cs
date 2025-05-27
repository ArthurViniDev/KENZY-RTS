using UnityEngine;

[System.Serializable]
public struct BuildCost
{
    public int wood;
    public int stone;
    public int food;

    public BuildCost(int wood, int stone, int food)
    {
        this.wood = wood;
        this.stone = stone;
        this.food = food;
    }
}

public class BaseBuild : MonoBehaviour
{
    [HideInInspector] public float buildTime = 5f;
    [HideInInspector] public GameObject buildingPrefab;
    public BuildCost buildPrice;

    public virtual void StartBuild()
    {
        if (PlayerManager.instance.HasEnoughResources(buildPrice))
        {
            PlayerManager.instance.SpendResources(buildPrice);
            Debug.Log($"Started building {buildingPrefab.name} for {buildPrice.wood} wood, {buildPrice.stone} stone, and {buildPrice.food} food.");
        }
        else
        {
            Debug.Log("Not enough resources to build.");
        }
    }
}
