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
    public GameObject buildingPrefab;
    public BuildCost buildPrice;
}
