using TMPro;
using UnityEngine;

[System.Serializable]
public struct Resources
{
    public int wood;
    public int stone;
    public int food;

    public Resources(int wood, int stone, int food)
    {
        this.wood = wood;
        this.stone = stone;
        this.food = food;
    }
}

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance; // Singleton pattern

    [Header("Player Stats")]
    public int peasantPoints = 1, windowsOpened;

    [Header("Player Resource Stats")]
    public Resources playerResources;
    private Resources lastResources;

    [Header("Resource UI")]
    public TextMeshProUGUI woodText;
    public TextMeshProUGUI stoneText;
    public TextMeshProUGUI foodText;

    private void Awake()
    {
        if (!instance) instance = this;
        else Destroy(gameObject);

        playerResources = new(
            5,
            5,
            5
        );
    }

    private void Update()
    {
        if (lastResources.wood == playerResources.wood &&
            lastResources.stone == playerResources.stone &&
            lastResources.food == playerResources.food) return;

        UpdateResourcesUI();
        lastResources = playerResources;
    }

    private void UpdateResourcesUI()
    {
        woodText.text = $"Woods: {playerResources.wood}";
        stoneText.text = $"Stones: {playerResources.stone}";
        foodText.text = $"Foods: {playerResources.food}";
    }

    public bool HasEnoughResources(Resources cost)
    {
        return playerResources.wood >= cost.wood &&
               playerResources.stone >= cost.stone &&
               playerResources.food >= cost.food;
    }

    public void SpendResources(int woodCost, int stoneCost, int foodCost)
    {
        playerResources.wood -= woodCost;
        playerResources.stone -= stoneCost;
        playerResources.food -= foodCost;
    }

    public void RefundResources(int woodValue, int stoneValue, int foodValue)
    {
        playerResources.wood += woodValue;
        playerResources.stone += stoneValue;
        playerResources.food += foodValue;
    }
}